namespace SMARDapi.Models.FilterTypes;

public abstract class SmardFilterType
{
}


/// <summary>
/// Represents a generic SMARD (Strommarktdaten) filter type.
/// </summary>
/// <typeparam name="T">The derived filter type.</typeparam>
public abstract class SmardFilterType<T> : SmardFilterType where T : SmardFilterType<T>
{
    /// <summary>
    /// Stores instances of the derived filter type.
    /// </summary>
    private static readonly Dictionary<string, T> Instances = new();

    /// <summary>
    /// Gets the string value associated with the filter type.
    /// </summary>
    private string Value { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SmardFilterType{T}"/> class.
    /// </summary>
    /// <param name="value">The string value representing the filter type.</param>
    protected SmardFilterType(string value)
    {
        Value = value;

        if (!Instances.ContainsKey(value))
        {
            Instances[value] = (T)this;
        }
    }

    /// <summary>
    /// Returns the string value associated with the filter type.
    /// </summary>
    /// <returns>The string value associated with the filter type.</returns>
    public override string ToString() => Value;

    /// <summary>
    /// Gets a read-only list of all instances of the derived filter type.
    /// </summary>
    public static IReadOnlyList<T> Values => new List<T>(Instances.Values).AsReadOnly();
}