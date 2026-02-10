using System.Collections;
using SpotifyWebApi.Core.Models;

namespace SpotifyWebApi.Core;

public class TemplateParamsFactory
{
    private readonly IReadOnlyCollection<TemplateParam> _defaultParams;

    public TemplateParamsFactory(IReadOnlyCollection<TemplateParam> defaultParams) => _defaultParams = defaultParams;

    public string Create(string hostPath, IReadOnlyCollection<TemplateParam> templateParams)
    {
        if (string.IsNullOrEmpty(hostPath))
            return hostPath;

        var url = hostPath;

        foreach (var (key, value) in templateParams.Concat(_defaultParams))
        {
            string replacement;

            // Accept any IEnumerable (generic or non-generic) but exclude string
            if (value is IEnumerable enumerable and not string)
            {
                // Build joined replacement from items
                var parts =
                    (from object? item in enumerable select Uri.EscapeDataString(item?.ToString() ?? "")).ToList();
                replacement = string.Join("/", parts);
            }
            else
            {
                replacement = Uri.EscapeDataString(value?.ToString() ?? "");
            }

            url = url.Replace($"{{{key}}}", replacement);
        }

        return url;
    }
}