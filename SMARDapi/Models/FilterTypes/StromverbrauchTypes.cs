namespace SMARDapi.Models.FilterTypes;

/// <summary>
/// Represents the SMARD (Strommarktdaten) electricity consumption filter options.
/// </summary>
public sealed class StromverbrauchTypes : FilterBase<StromverbrauchTypes>
{
    /// <summary>
    /// Represents the electricity consumption filter "GesamtNetzlast" (Total Grid Load) with the value "410".
    /// </summary>
    public static readonly StromverbrauchTypes GesamtNetzlast = new("410");

    /// <summary>
    /// Represents the electricity consumption filter "Residuallast" (Residual Load) with the value "4359".
    /// </summary>
    public static readonly StromverbrauchTypes Residuallast = new("4359");

    /// <summary>
    /// Represents the electricity consumption filter "Pumpspeicher" (Pumped Storage) with the value "4387".
    /// </summary>
    public static readonly StromverbrauchTypes Pumpspeicher = new("4387");

    /// <summary>
    /// Initializes a new instance of the <see cref="StromverbrauchTypes"/> class.
    /// </summary>
    /// <param name="value">The string value representing the electricity consumption filter option.</param>
    private StromverbrauchTypes(string value) : base(value)
    {
    }
}
