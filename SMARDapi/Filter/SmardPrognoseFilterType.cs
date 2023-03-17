namespace SMARDapi.Filter;

public class SmardPrognoseFilterType : SmardFilterType
{
    public static readonly SmardPrognoseFilterType Offshore = new("3791");
    public static readonly SmardPrognoseFilterType Onshore = new("123");
    public static readonly SmardPrognoseFilterType Photovoltaik = new("125");
    public static readonly SmardPrognoseFilterType Sonstige = new("715");
    public static readonly SmardPrognoseFilterType WindUndPhotovoltaik = new("5097");
    public static readonly SmardPrognoseFilterType Gesamt = new("122");

    private SmardPrognoseFilterType(string value) : base(value)
    {
    }
}