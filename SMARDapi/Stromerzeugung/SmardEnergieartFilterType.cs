using SMARDapi.Models.FilterTypes;

namespace SMARDapi.Stromerzeugung;

/// <summary>
/// Represents the SMARD (Strommarktdaten) energy type filter options.
/// </summary>
public sealed class SmardEnergieartFilterType : SmardFilterType<SmardEnergieartFilterType>
{
    /// <summary>
    /// Represents the energy type "Braunkohle" (Lignite) with the value "1223".
    /// </summary>
    public static readonly SmardEnergieartFilterType Braunkohle = new("1223");

    /// <summary>
    /// Represents the energy type "Kernenergie" (Nuclear Energy) with the value "1224".
    /// </summary>
    public static readonly SmardEnergieartFilterType Kernenergie = new("1224");

    /// <summary>
    /// Represents the energy type "WindOffshore" (Offshore Wind) with the value "1225".
    /// </summary>
    public static readonly SmardEnergieartFilterType WindOffshore = new("1225");

    /// <summary>
    /// Represents the energy type "Wasserkraft" (Hydropower) with the value "1226".
    /// </summary>
    public static readonly SmardEnergieartFilterType Wasserkraft = new("1226");

    /// <summary>
    /// Represents the energy type "SonstigeKonventionelle" (Other Conventional) with the value "1227".
    /// </summary>
    public static readonly SmardEnergieartFilterType SonstigeKonventionelle = new("1227");

    /// <summary>
    /// Represents the energy type "SonstigeErneuerbare" (Other Renewables) with the value "1228".
    /// </summary>
    public static readonly SmardEnergieartFilterType SonstigeErneuerbare = new("1228");

    /// <summary>
    /// Represents the energy type "Biomasse" (Biomass) with the value "4066".
    /// </summary>
    public static readonly SmardEnergieartFilterType Biomasse = new("4066");

    /// <summary>
    /// Represents the energy type "WindOnshore" (Onshore Wind) with the value "4067".
    /// </summary>
    public static readonly SmardEnergieartFilterType WindOnshore = new("4067");

    /// <summary>
    /// Represents the energy type "Photovoltaik" (Photovoltaic) with the value "4068".
    /// </summary>
    public static readonly SmardEnergieartFilterType Photovoltaik = new("4068");

    /// <summary>
    /// Represents the energy type "Steinkohle" (Hard Coal) with the value "4069".
    /// </summary>
    public static readonly SmardEnergieartFilterType Steinkohle = new("4069");

    /// <summary>
    /// Represents the energy type "Pumpspeicher" (Pumped Storage) with the value "4070".
    /// </summary>
    public static readonly SmardEnergieartFilterType Pumpspeicher = new("4070");

    /// <summary>
    /// Represents the energy type "Erdgas" (Natural Gas) with the value "4071".
    /// </summary>
    public static readonly SmardEnergieartFilterType Erdgas = new("4071");

    /// <summary>
    /// Initializes a new instance of the <see cref="SmardEnergieartFilterType"/> class.
    /// </summary>
    /// <param name="value">The string value representing the energy type.</param>
    private SmardEnergieartFilterType(string value) : base(value)
    {
    }
}