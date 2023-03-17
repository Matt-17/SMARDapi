namespace SMARDapi.Models;

public sealed class SmardValue
{
    public SmardTimestamp Timestamp { get; set; }

    public decimal? Value { get; set; }

    public override string ToString()
    {
        return $"{Timestamp}: {Value}";
    }
}