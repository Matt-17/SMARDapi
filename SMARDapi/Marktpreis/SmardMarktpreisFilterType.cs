using SMARDapi.Models.FilterTypes;

namespace SMARDapi.Marktpreis;

/// <summary>
/// Represents the SMARD (Strommarktdaten) market price filter options for different regions.
/// </summary>
public sealed class SmardMarktpreisFilterType : SmardFilterType<SmardMarktpreisFilterType>
{
    /// <summary>
    /// Represents the region "DeutschlandLuxemburg" (Germany & Luxembourg) with the value "4169".
    /// </summary>
    public static readonly SmardMarktpreisFilterType DeutschlandLuxemburg = new("4169");

    /// <summary>
    /// Represents the region "AnrainerDELu" (Neighboring DE-LU) with the value "5078".
    /// </summary>
    public static readonly SmardMarktpreisFilterType AnrainerDELu = new("5078");

    /// <summary>
    /// Represents the region "Belgien" (Belgium) with the value "4996".
    /// </summary>
    public static readonly SmardMarktpreisFilterType Belgien = new("4996");

    /// <summary>
    /// Represents the region "Norwegen2" (Norway 2) with the value "4997".
    /// </summary>
    public static readonly SmardMarktpreisFilterType Norwegen2 = new("4997");

    /// <summary>
    /// Represents the region "Oesterreich" (Austria) with the value "4170".
    /// </summary>
    public static readonly SmardMarktpreisFilterType Oesterreich = new("4170");

    /// <summary>
    /// Represents the region "Daenemark1" (Denmark 1) with the value "252".
    /// </summary>
    public static readonly SmardMarktpreisFilterType Daenemark1 = new("252");

    /// <summary>
    /// Represents the region "Daenemark2" (Denmark 2) with the value "253".
    /// </summary>
    public static readonly SmardMarktpreisFilterType Daenemark2 = new("253");

    /// <summary>
    /// Represents the region "Frankreich" (France) with the value "254".
    /// </summary>
    public static readonly SmardMarktpreisFilterType Frankreich = new("254");

    /// <summary>
    /// Represents the region "ItalienNord" (Northern Italy) with the value "255".
    /// </summary>
    public static readonly SmardMarktpreisFilterType ItalienNord = new("255");

    /// <summary>
    /// Represents the region "Niederlande" (Netherlands) with the value "256".
    /// </summary>
    public static readonly SmardMarktpreisFilterType Niederlande = new("256");

    /// <summary>
    /// Represents the region "Polen1" (Poland 1) with the value "257".
    /// </summary>
    public static readonly SmardMarktpreisFilterType Polen1 = new("257");

    /// <summary>
    /// Represents the region "Polen2" (Poland 2) with the value "258".
    /// </summary>
    public static readonly SmardMarktpreisFilterType Polen2 = new("258");

    /// <summary>
    /// Represents the region "Schweiz" (Switzerland) with the value "259".
    /// </summary>
    public static readonly SmardMarktpreisFilterType Schweiz = new("259");

    /// <summary>
    /// Represents the region "Slowenien" (Slovenia) with the value "260".
    /// </summary>

    public static readonly SmardMarktpreisFilterType Slowenien = new("260");

    /// <summary>
    /// Represents the region "Tschechien" (Czech Republic) with the value "261".
    /// </summary>
    public static readonly SmardMarktpreisFilterType Tschechien = new("261");

    /// <summary>
    /// Represents the region "Ungarn" (Hungary) with the value "262".
    /// </summary>
    public static readonly SmardMarktpreisFilterType Ungarn = new("262");

    /// <summary>
    /// Initializes a new instance of the <see cref="SmardMarktpreisFilterType"/> class.
    /// </summary>
    /// <param name="value">The string value representing the region.</param>
    private SmardMarktpreisFilterType(string value) : base(value)
    {
    }
}