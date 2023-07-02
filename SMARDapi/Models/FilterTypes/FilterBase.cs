namespace SMARDapi.Models.FilterTypes;

/// <summary>
/// Represents a generic SMARD (Strommarktdaten) filter type.
/// </summary>
/// <typeparam name="T">The derived filter type.</typeparam>
public abstract class FilterBase<T> : SmardFilterType where T : FilterBase<T>
{
    /// <summary>
    /// Gets the string value associated with the filter type.
    /// </summary>
    protected string Value { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="FilterBase{T}"/> class.
    /// </summary>
    /// <param name="value">The string value representing the filter type.</param>
    protected FilterBase(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Returns the string value associated with the filter type.
    /// </summary>
    /// <returns>The string value associated with the filter type.</returns>
    public override string ToString() => Value;
}