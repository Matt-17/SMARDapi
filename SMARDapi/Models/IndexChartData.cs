using SMARDapi.Models.Internal;

namespace SMARDapi.Models;

/// <summary>
/// Represents the result of a chart index query.
/// </summary>
public sealed class IndexChartData
{
    /// <summary>
    /// Gets the available timestamps for the chart data.
    /// </summary>
    public IReadOnlyList<SmardTimestamp> Timestamps { get; }

    /// <summary>
    /// Creates an empty index chart data result.
    /// </summary>
    public IndexChartData()
    {
        Timestamps = new List<SmardTimestamp>();
    }

    internal IndexChartData(IndexChartDataInternal dataInternal)
    {
        IEnumerable<long> timestamps = dataInternal.Timestamps;
        Timestamps = timestamps.Select(t => new SmardTimestamp(t)).ToList();
    }
}
