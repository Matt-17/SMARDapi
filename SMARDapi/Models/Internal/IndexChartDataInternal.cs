using System.Text.Json.Serialization;

namespace SMARDapi.Models.Internal;

internal class IndexChartDataInternal
{
    [JsonPropertyName("timestamps")]
    public long[] Timestamps { get; set; } = null!;
}