using System.Text.Json.Serialization;

namespace SMARDapi.Models.Internal;

internal class SeriesInternal
{
    [JsonPropertyName("values")]
    public ValueInternal[] Values { get; set; } = null!;
}