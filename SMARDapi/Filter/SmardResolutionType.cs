namespace SMARDapi.Filter;

public sealed class SmardResolutionType : SmardFilterType
{
    public static readonly SmardResolutionType Hour = new("hour");
    public static readonly SmardResolutionType QuarterHour = new("quarterhour");
    public static readonly SmardResolutionType Day = new("day");
    public static readonly SmardResolutionType Week = new("week");
    public static readonly SmardResolutionType Month = new("month");
    public static readonly SmardResolutionType Year = new("year");

    private SmardResolutionType(string value) : base(value)
    {
    }
}
