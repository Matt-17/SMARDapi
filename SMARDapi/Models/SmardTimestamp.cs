namespace SMARDapi.Models;

public class SmardTimestamp
{
    public long Timestamp { get; }
    public DateTime DateTime { get; }

    public SmardTimestamp(long timestamp)
    {
        Timestamp = timestamp;
        DateTime = DateTimeOffset.FromUnixTimeMilliseconds(timestamp).DateTime;
    }

    public override string ToString()
    {
        return DateTime.ToString("dd.MM.yyyy HH:mm");
    }
}