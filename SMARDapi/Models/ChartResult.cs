using SMARDapi.Models.Internal;

namespace SMARDapi.Models;

/// <summary>
/// Represents a single value of a time series.
/// </summary>
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

    /// <summary>
    /// Meta data of the result.
    /// </summary>
    public MetaData MetaData { get; set; }

    /// <summary>
    /// List of values for the chart data.
    /// </summary>
    public List<SmardValue> Series { get; set; }
}