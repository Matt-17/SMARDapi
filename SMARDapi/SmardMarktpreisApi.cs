using System.Text.Json.Serialization;

using SMARDapi.Filter;


namespace SMARDapi;

public class SmardMarktpreisApi : SmardApiBase
{
    public SmardMarktpreisApi(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<IndexChartData?> GetIndexChartData(SmardRegionType region, SmardResolutionType resolution, SmardMarktpreisFilterType filter)
    {
        return await GetIndexChartDataInternal(region, resolution, filter);
    }

    public async Task<ChartResult> GetChartData(SmardRegionType region, SmardMarktpreisFilterType filter, SmardResolutionType resolution, SmardTimestamp dateTime)
    {
        return await GetChartDataInternal(region, filter, resolution, dateTime);
    }
}

internal class MetaDataInternal
{
    [JsonPropertyName("version")]
    public int Version { get; set; }
    [JsonPropertyName("created")]
    public long Created { get; set; }
}

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
public sealed class MetaData
{
    public int Version { get; set; }

    public SmardTimestamp Created { get; set; }

    public override string ToString()
    {
        return $"{Version} - {Created}";
    }
}

public sealed class ChartResult
{
    internal ChartResult(ChartResultInternal chartResultInternal)
    {
        MetaData = new MetaData
        {
            Version = chartResultInternal.MetaData.Version,
            Created = new SmardTimestamp(chartResultInternal.MetaData.Created)
        };


        Series = new List<SmardValue>();
        foreach (var series in chartResultInternal.Series)
        {
            var timestamp = (long)series[0];
            Series.Add(new SmardValue
            {
                Timestamp = new SmardTimestamp(timestamp),
                Value = (decimal?)series[1]
            });
        }
    }

    public MetaData MetaData { get; set; }

    public List<SmardValue> Series { get; set; }
}

public sealed class SmardValue
{
    public SmardTimestamp Timestamp { get; set; }

    public decimal? Value { get; set; }

    public override string ToString()
    {
        return $"{Timestamp}: {Value}";
    }
}