using Polly;
using Polly.Retry;
using SpotifyWebApi.Core.Configuration;
using SpotifyWebApi.Core.Request;

namespace SpotifyWebApi.Core;

public class ResiliencePipelineFactory
{
    private readonly ResiliencePipeline<HttpResponseMessage> _pipeline;
    private static readonly Random Jitterer = new();

    public ResiliencePipelineFactory(RetryOptions options)
    {
        _pipeline = CreateResiliencePipeline(options);
    }

    public ResiliencePipeline<HttpResponseMessage> Create(IRequest request) => 
        request.CanRetry ? _pipeline : ResiliencePipeline<HttpResponseMessage>.Empty;

    private static ResiliencePipeline<HttpResponseMessage> CreateResiliencePipeline(RetryOptions options) =>
        new ResiliencePipelineBuilder<HttpResponseMessage>()
            .AddRetry(new RetryStrategyOptions<HttpResponseMessage>
            {
                ShouldHandle = new PredicateBuilder<HttpResponseMessage>()
                    .Handle<HttpRequestException>()
                    .HandleResult(msg =>
                        options.StatusCodesToRetry.Contains(msg.StatusCode) &&
                        options.HttpMethodsToRetry.Contains(msg.RequestMessage.Method)),
                MaxRetryAttempts = options.MaxRetries,
                DelayGenerator = args =>
                {
                    var retryAttempt = args.AttemptNumber + 1;
                    double delayMs;

                    if (options.UseExponentialBackoff)
                    {
                        delayMs = options.Delay.TotalMilliseconds *
                                  Math.Pow(options.BackOffFactor, retryAttempt - 1);
                    }
                    else
                    {
                        delayMs = options.Delay.TotalMilliseconds;
                    }

                    int jitterMs;
                    lock (Jitterer)
                    {
                        jitterMs = Jitterer.Next((int)options.MaxJitter.TotalMilliseconds);
                    }

                    return new ValueTask<TimeSpan?>(TimeSpan.FromMilliseconds(delayMs + jitterMs));
                },
                OnRetry = args =>
                {
                    options.OnRetry?.Invoke(
                        args.Outcome.Exception ?? new Exception($"HTTP {args.Outcome.Result?.StatusCode}"),
                        args.RetryDelay,
                        args.AttemptNumber + 1);
                    return default;
                }
            })
            .Build();
}
