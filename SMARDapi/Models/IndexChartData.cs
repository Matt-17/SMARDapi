namespace SMARDapi.Models;

public sealed class IndexChartData
{
    public IReadOnlyList<SmardTimestamp> Timestamps { get; }

    internal IndexChartData(IEnumerable<long> timestamps)
    {
        Timestamps = timestamps.Select(t => new SmardTimestamp(t)).ToList();
    }
}