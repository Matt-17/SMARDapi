namespace SMARDapi.Models;

/// <summary>
/// Represents a SMARD (Strommarktdaten) value.
/// </summary>
public sealed class SmardValue
{
    /// <summary>
    /// Timestamp of the value.
    /// </summary>
    public SmardTimestamp Timestamp { get; set; } = null!;

    /// <summary>
    /// Value of the value.
    /// </summary>
    public decimal? Value { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{Timestamp}: {Value}";
    }
}