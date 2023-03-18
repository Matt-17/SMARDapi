namespace SMARDapi.Models.FilterTypes;

/// <summary>
/// Represents the SMARD (Strommarktdaten) region filter options.
/// </summary>
public sealed class Regions : FilterBase<Regions>
{
    /// <summary>
    /// Represents the region "DE" (Germany) with the value "DE".
    /// </summary>
    public static Regions DE = new("DE");

    /// <summary>
    /// Represents the region "AT" (Austria) with the value "AT".
    /// </summary>
    public static Regions AT = new("AT");

    /// <summary>
    /// Represents the region "LU" (Luxembourg) with the value "LU".
    /// </summary>
    public static Regions LU = new("LU");

    /// <summary>
    /// Represents the region "DELU" (Germany & Luxembourg) with the value "DE-LU".
    /// </summary>
    public static Regions DELU = new("DE-LU");

    /// <summary>
    /// Represents the region "DEATLU" (Germany, Austria & Luxembourg) with the value "DE-AT-LU".
    /// </summary>
    public static Regions DEATLU = new("DE-AT-LU");

    /// <summary>
    /// Represents the region "Hertz50" (50Hertz) with the value "50Hertz".
    /// </summary>
    public static Regions Hertz50 = new("50Hertz");

    /// <summary>
    /// Represents the region "Amprion" with the value "Amprion".
    /// </summary>
    public static Regions Amprion = new("Amprion");

    /// <summary>
    /// Represents the region "TenneT" with the value "TenneT".
    /// </summary>
    public static Regions TenneT = new("TenneT");

    /// <summary>
    /// Represents the region "TransnetBW" with the value "TransnetBW".
    /// </summary>
    public static Regions TransnetBW = new("TransnetBW");

    /// <summary>
    /// Represents the region "APG" with the value "APG".
    /// </summary>
    public static Regions APG = new("APG");

    /// <summary>
    /// Represents the region "Creos" with the value "Creos".
    /// </summary>
    public static Regions Creos = new("Creos");

    /// <summary>
    /// Initializes a new instance of the <see cref="Regions"/> class.
    /// </summary>
    /// <param name="value">The string value representing the region.</param>
    private Regions(string value) : base(value)
    {
    }
}
