using System.Text.Json.Serialization;

namespace SMARDapi.Models.Internal;

internal class TableResultInternal
{
    [JsonPropertyName("meta_data")]
    public MetaDataInternal MetaData { get; set; } = null!;

    [JsonPropertyName("series")]
    public SeriesInternal[] Series { get; set; } = null!;
}