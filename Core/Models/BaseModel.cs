using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpotifyWebApi.Core.Models;

public abstract class BaseModel
{
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? AdditionalProperties { get; set; } = new Dictionary<string, JsonElement>();
}