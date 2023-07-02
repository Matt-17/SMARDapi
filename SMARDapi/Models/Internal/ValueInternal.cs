using System.Text.Json.Serialization;

namespace SMARDapi.Models.Internal;

internal class ValueInternal
{
    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; }

    [JsonPropertyName("versions")]
    public VersionInternal[] Versions { get; set; } = null!;
}