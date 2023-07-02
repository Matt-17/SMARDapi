using SMARDapi.Models.Internal;

namespace SMARDapi.Models;

/// <summary>
/// Represents the result of a chart query.
/// </summary>
public sealed class IndexChartData
{
    /// <summary>
    /// List of timestamps for the chart data.
    /// </summary>
    public IReadOnlyList<SmardTimestamp> Timestamps { get; }

    internal IndexChartData(IndexChartDataInternal dataInternal)
    {
        IEnumerable<long> timestamps = dataInternal.Timestamps;
        Timestamps = timestamps.Select(t => new SmardTimestamp(t)).ToList();
    }
}