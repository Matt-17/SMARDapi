using SMARDapi.Models.FilterTypes;

namespace SMARDapi.Stromverbrauch;

/// <summary>
/// Represents the SMARD (Strommarktdaten) electricity consumption filter options.
/// </summary>
public sealed class SmardStromverbrauchFilterType : SmardFilterType<SmardStromverbrauchFilterType>
{
    /// <summary>
    /// Represents the electricity consumption filter "GesamtNetzlast" (Total Grid Load) with the value "410".
    /// </summary>
    public static readonly SmardStromverbrauchFilterType GesamtNetzlast = new("410");

    /// <summary>
    /// Represents the electricity consumption filter "Residuallast" (Residual Load) with the value "4359".
    /// </summary>
    public static readonly SmardStromverbrauchFilterType Residuallast = new("4359");

    /// <summary>
    /// Represents the electricity consumption filter "Pumpspeicher" (Pumped Storage) with the value "4387".
    /// </summary>
    public static readonly SmardStromverbrauchFilterType Pumpspeicher = new("4387");

    /// <summary>
    /// Initializes a new instance of the <see cref="SmardStromverbrauchFilterType"/> class.
    /// </summary>
    /// <param name="value">The string value representing the electricity consumption filter option.</param>
    private SmardStromverbrauchFilterType(string value) : base(value)
    {
    }
}
