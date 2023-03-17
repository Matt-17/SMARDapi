using SMARDapi.Models.FilterTypes;

namespace SMARDapi.Prognose;

/// <summary>
/// Represents the SMARD (Strommarktdaten) prognosis filter options.
/// </summary>
public sealed class SmardPrognoseFilterType : SmardFilterType<SmardPrognoseFilterType>
{
    /// <summary>
    /// Represents the prognosis filter "Offshore" (Offshore Wind) with the value "3791".
    /// </summary>
    public static readonly SmardPrognoseFilterType Offshore = new("3791");

    /// <summary>
    /// Represents the prognosis filter "Onshore" (Onshore Wind) with the value "123".
    /// </summary>
    public static readonly SmardPrognoseFilterType Onshore = new("123");

    /// <summary>
    /// Represents the prognosis filter "Photovoltaik" (Photovoltaic) with the value "125".
    /// </summary>
    public static readonly SmardPrognoseFilterType Photovoltaik = new("125");

    /// <summary>
    /// Represents the prognosis filter "Sonstige" (Other) with the value "715".
    /// </summary>
    public static readonly SmardPrognoseFilterType Sonstige = new("715");

    /// <summary>
    /// Represents the prognosis filter "WindUndPhotovoltaik" (Wind and Photovoltaic) with the value "5097".
    /// </summary>
    public static readonly SmardPrognoseFilterType WindUndPhotovoltaik = new("5097");

    /// <summary>
    /// Represents the prognosis filter "Gesamt" (Total) with the value "122".
    /// </summary>
    public static readonly SmardPrognoseFilterType Gesamt = new("122");

    /// <summary>
    /// Initializes a new instance of the <see cref="SmardPrognoseFilterType"/> class.
    /// </summary>
    /// <param name="value">The string value representing the prognosis filter option.</param>
    private SmardPrognoseFilterType(string value) : base(value)
    {
    }
}
