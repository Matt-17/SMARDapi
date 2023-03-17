namespace SMARDapi.Filter;

/// <summary>
/// Represents a region for the SMARD API.
/// </summary>
public sealed class SmardRegionType : SmardFilterType
{
    /// <summary>
    /// Land: Deutschland
    /// </summary>
    public static SmardRegionType DE = new("DE");

    /// <summary>
    /// Land: Österreich
    /// </summary>
    public static SmardRegionType AT = new("AT");

    /// <summary>
    /// Land: Luxemburg
    /// </summary>
    public static SmardRegionType LU = new("LU");

    /// <summary>
    /// Marktgebiet: DE/LU (ab 01.10.2018)
    /// </summary>
    public static SmardRegionType DELU = new("DE-LU");

    /// <summary>
    /// Marktgebiet: DE/AT/LU (bis 30.09.2018)
    /// </summary>
    public static SmardRegionType DEATLU = new("DE-AT-LU");

    /// <summary>
    /// Regelzone (DE): 50Hertz
    /// </summary>
    public static SmardRegionType Hertz50 = new("50Hertz");

    /// <summary>
    /// Regelzone (DE): Amprion
    /// </summary>
    public static SmardRegionType Amprion = new("Amprion");

    /// <summary>
    /// Regelzone (DE): TenneT
    /// </summary>
    public static SmardRegionType TenneT = new("TenneT");

    /// <summary>
    /// Regelzone (DE): TransnetBW
    /// </summary>
    public static SmardRegionType TransnetBW = new("TransnetBW");

    /// <summary>
    /// Regelzone (AT): APG
    /// </summary>
    public static SmardRegionType APG = new("APG");

    /// <summary>
    /// Regelzone (LU): Creos
    /// </summary>
    public static SmardRegionType Creos = new("Creos");


    private SmardRegionType(string value) : base(value)
    {
    }
}