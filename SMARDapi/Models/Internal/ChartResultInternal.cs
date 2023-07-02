using System.Text.Json.Serialization;

namespace SMARDapi.Models.Internal;

internal class ChartResultInternal
{
    [JsonPropertyName("meta_data")]
    public MetaDataInternal MetaData { get; set; } = null!;

    [JsonPropertyName("series")]
    public double[][] Series { get; set; } = null!;
}