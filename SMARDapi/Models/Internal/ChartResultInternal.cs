using System.Text.Json.Serialization;

namespace SMARDapi.Models.Internal;

internal class ChartResultInternal
{
    public ChartResultInternal()
    {
    }

    [JsonPropertyName("meta_data")]
    public MetaDataInternal MetaData { get; set; }
    [JsonPropertyName("series")]
    public double?[][] Series { get; set; }
}