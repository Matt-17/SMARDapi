namespace SMARDapi.Models;

/// <summary>
/// Represents a timestamp used in the SMARD (Strommarktdaten) API.
/// </summary>
public class SmardTimestamp
{
    /// <summary>
    /// The value of the timestamp.
    /// </summary>
    public long Value { get; }

    /// <summary>
    /// The <see cref="DateTime"/> representation of the timestamp.
    /// </summary>
    public DateTime DateTime { get; }

    /// <summary>
    /// Creates a new instance of <see cref="SmardTimestamp"/>.
    /// </summary>
    /// <param name="value"></param>
    public SmardTimestamp(long value)
    {
        Value = value;
        DateTime = DateTimeOffset.FromUnixTimeMilliseconds(value).DateTime;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return DateTime.ToString("dd.MM.yyyy HH:mm");
    }
}