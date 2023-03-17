namespace SMARDapi.Filter;

public class SmardEnergieartFilterType : SmardFilterType
{
    public static readonly SmardEnergieartFilterType Braunkohle = new("1223");
    public static readonly SmardEnergieartFilterType Kernenergie = new("1224");
    public static readonly SmardEnergieartFilterType WindOffshore = new("1225");
    public static readonly SmardEnergieartFilterType Wasserkraft = new("1226");
    public static readonly SmardEnergieartFilterType SonstigeKonventionelle = new("1227");
    public static readonly SmardEnergieartFilterType SonstigeErneuerbare = new("1228");
    public static readonly SmardEnergieartFilterType Biomasse = new("4066");
    public static readonly SmardEnergieartFilterType WindOnshore = new("4067");
    public static readonly SmardEnergieartFilterType Photovoltaik = new("4068");
    public static readonly SmardEnergieartFilterType Steinkohle = new("4069");
    public static readonly SmardEnergieartFilterType Pumpspeicher = new("4070");
    public static readonly SmardEnergieartFilterType Erdgas = new("4071");

    private SmardEnergieartFilterType(string value) : base(value)
    {
    }
}