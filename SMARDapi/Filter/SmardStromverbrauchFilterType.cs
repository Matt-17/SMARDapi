namespace SMARDapi.Filter;

public class SmardStromverbrauchFilterType : SmardFilterType
{
    public static readonly SmardStromverbrauchFilterType GesamtNetzlast = new("410");
    public static readonly SmardStromverbrauchFilterType Residuallast = new("4359");
    public static readonly SmardStromverbrauchFilterType Pumpspeicher = new("4387");

    private SmardStromverbrauchFilterType(string value) : base(value)
    {
    }
}