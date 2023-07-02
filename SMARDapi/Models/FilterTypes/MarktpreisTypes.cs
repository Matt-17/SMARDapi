using System.Collections;

namespace SMARDapi.Models.FilterTypes;

/// <summary>
/// Represents the SMARD (Strommarktdaten) market price filter options for different regions.
/// </summary>
public sealed class MarktpreisTypes : FilterBase<MarktpreisTypes>
{
    /// <summary>
    /// Represents the region "DeutschlandLuxemburg" (Germany &amp; Luxembourg) with the value "4169".
    /// </summary>
    public static readonly MarktpreisTypes DeutschlandLuxemburg = new("4169");

    /// <summary>
    /// Represents the region "AnrainerDELu" (Neighboring DE-LU) with the value "5078".
    /// </summary>
    public static readonly MarktpreisTypes AnrainerDELu = new("5078");

    /// <summary>
    /// Represents the region "Belgien" (Belgium) with the value "4996".
    /// </summary>
    public static readonly MarktpreisTypes Belgien = new("4996");

    /// <summary>
    /// Represents the region "Norwegen2" (Norway 2) with the value "4997".
    /// </summary>
    public static readonly MarktpreisTypes Norwegen2 = new("4997");

    /// <summary>
    /// Represents the region "Oesterreich" (Austria) with the value "4170".
    /// </summary>
    public static readonly MarktpreisTypes Oesterreich = new("4170");

    /// <summary>
    /// Represents the region "Daenemark1" (Denmark 1) with the value "252".
    /// </summary>
    public static readonly MarktpreisTypes Daenemark1 = new("252");

    /// <summary>
    /// Represents the region "Daenemark2" (Denmark 2) with the value "253".
    /// </summary>
    public static readonly MarktpreisTypes Daenemark2 = new("253");

    /// <summary>
    /// Represents the region "Frankreich" (France) with the value "254".
    /// </summary>
    public static readonly MarktpreisTypes Frankreich = new("254");

    /// <summary>
    /// Represents the region "ItalienNord" (Northern Italy) with the value "255".
    /// </summary>
    public static readonly MarktpreisTypes ItalienNord = new("255");

    /// <summary>
    /// Represents the region "Niederlande" (Netherlands) with the value "256".
    /// </summary>
    public static readonly MarktpreisTypes Niederlande = new("256");

    /// <summary>
    /// Represents the region "Polen1" (Poland 1) with the value "257".
    /// </summary>
    public static readonly MarktpreisTypes Polen1 = new("257");

    /// <summary>
    /// Represents the region "Polen2" (Poland 2) with the value "258".
    /// </summary>
    public static readonly MarktpreisTypes Polen2 = new("258");

    /// <summary>
    /// Represents the region "Schweiz" (Switzerland) with the value "259".
    /// </summary>
    public static readonly MarktpreisTypes Schweiz = new("259");

    /// <summary>
    /// Represents the region "Slowenien" (Slovenia) with the value "260".
    /// </summary>

    public static readonly MarktpreisTypes Slowenien = new("260");

    /// <summary>
    /// Represents the region "Tschechien" (Czech Republic) with the value "261".
    /// </summary>
    public static readonly MarktpreisTypes Tschechien = new("261");

    /// <summary>
    /// Represents the region "Ungarn" (Hungary) with the value "262".
    /// </summary>
    public static readonly MarktpreisTypes Ungarn = new("262");

    /// <summary>
    /// Initializes a new instance of the <see cref="MarktpreisTypes"/> class.
    /// </summary>
    /// <param name="value">The string value representing the region.</param>
    private MarktpreisTypes(string value) : base(value)
    {
    }
}