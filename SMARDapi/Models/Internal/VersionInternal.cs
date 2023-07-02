using System.Text.Json.Serialization;

namespace SMARDapi.Models.Internal;

internal class VersionInternal
{
    [JsonPropertyName("value")]
    public decimal? Value { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}