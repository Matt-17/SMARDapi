namespace SMARDapi.Models.FilterTypes;

/// <summary>
/// Represents SMARD generation type filters and their installed capacity counterparts.
/// </summary>
public sealed class EnergieartTypes : FilterBase<EnergieartTypes>
{
    /// <summary>
    /// Gets the SMARD filter id for generated electricity.
    /// </summary>
    public string Stromerzeugung => Value;

    /// <summary>
    /// Gets the SMARD filter id for installed generation capacity.
    /// </summary>
    public string Installiert { get; }

    /// <summary>
    /// Gets the human-readable display name.
    /// </summary>
    public string DisplayName { get; }

    private EnergieartTypes(string stromerzeugung, string installiert, string displayName) : base(stromerzeugung)
    {
        Installiert = installiert;
        DisplayName = displayName;
    }

    /// <summary>
    /// Brown coal generation.
    /// </summary>
    public static readonly EnergieartTypes Braunkohle = new("1223", "4072", "Braunkohle");

    /// <summary>
    /// Nuclear generation.
    /// </summary>
    public static readonly EnergieartTypes Kernenergie = new("1224", "4073", "Kernenergie");

    /// <summary>
    /// Offshore wind generation.
    /// </summary>
    public static readonly EnergieartTypes WindOffshore = new("1225", "4076", "Wind (Offshore)");

    /// <summary>
    /// Hydropower generation.
    /// </summary>
    public static readonly EnergieartTypes Wasserkraft = new("1226", "3792", "Wasserkraft");

    /// <summary>
    /// Other conventional generation.
    /// </summary>
    public static readonly EnergieartTypes SonstigeKonventionelle = new("1227", "207", "Sonstige konventionelle");

    /// <summary>
    /// Other renewable generation.
    /// </summary>
    public static readonly EnergieartTypes SonstigeErneuerbare = new("1228", "194", "Sonstige erneuerbare");

    /// <summary>
    /// Biomass generation.
    /// </summary>
    public static readonly EnergieartTypes Biomasse = new("4066", "189", "Biomasse");

    /// <summary>
    /// Onshore wind generation.
    /// </summary>
    public static readonly EnergieartTypes WindOnshore = new("4067", "186", "Wind (Festland)");

    /// <summary>
    /// Photovoltaic generation.
    /// </summary>
    public static readonly EnergieartTypes Photovoltaik = new("4068", "188", "Photovoltaik");

    /// <summary>
    /// Hard coal generation.
    /// </summary>
    public static readonly EnergieartTypes Steinkohle = new("4069", "4075", "Steinkohle");

    /// <summary>
    /// Pumped storage generation.
    /// </summary>
    public static readonly EnergieartTypes Pumpspeicher = new("4070", "4074", "Pumpspeicher");

    /// <summary>
    /// Natural gas generation.
    /// </summary>
    public static readonly EnergieartTypes Erdgas = new("4071", "198", "Erdgas");

    /// <summary>
    /// Gets all predefined generation type filters.
    /// </summary>
    public static IReadOnlyList<EnergieartTypes> Values => new[]
    {
        Braunkohle, Kernenergie, WindOffshore, Wasserkraft, SonstigeKonventionelle, SonstigeErneuerbare,
        Biomasse, WindOnshore, Photovoltaik, Steinkohle, Pumpspeicher, Erdgas
    };
}
