using SMARDapi.Models.Internal;

namespace SMARDapi.Models;

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