using SMARDapi.Models.FilterTypes;

namespace SMARDapi.Models;

/// <summary>
/// Represents the SMARD (Strommarktdaten) resolution filter options.
/// </summary>
public sealed class Resolutions : FilterBase<Resolutions>
{
    /// <summary>
    /// Represents the resolution filter "Hour" with the value "hour".
    /// </summary>
    public static readonly Resolutions Hour = new("hour");

    /// <summary>
    /// Represents the resolution filter "QuarterHour" with the value "quarterhour".
    /// </summary>
    public static readonly Resolutions QuarterHour = new("quarterhour");

    /// <summary>
    /// Represents the resolution filter "Day" with the value "day".
    /// </summary>
    public static readonly Resolutions Day = new("day");

    /// <summary>
    /// Represents the resolution filter "Week" with the value "week".
    /// </summary>
    public static readonly Resolutions Week = new("week");

    /// <summary>
    /// Represents the resolution filter "Month" with the value "month".
    /// </summary>
    public static readonly Resolutions Month = new("month");

    /// <summary>
    /// Represents the resolution filter "Year" with the value "year".
    /// </summary>
    public static readonly Resolutions Year = new("year");

    /// <summary>
    /// Initializes a new instance of the <see cref="Resolutions"/> class.
    /// </summary>
    /// <param name="value">The string value representing the resolution filter option.</param>
    private Resolutions(string value) : base(value)
    {
    }
}
