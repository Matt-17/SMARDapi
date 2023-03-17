using System.Text.Json.Serialization;

namespace SMARDapi.Models.Internal;

internal class MetaDataInternal
{
    [JsonPropertyName("version")]
    public int Version { get; set; }
    [JsonPropertyName("created")]
    public long Created { get; set; }
}