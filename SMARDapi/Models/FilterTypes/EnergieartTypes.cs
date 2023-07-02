using System.Collections;
using System.ComponentModel;

namespace SMARDapi.Models.FilterTypes;
public sealed class EnergieartTypes : FilterBase<EnergieartTypes>
{
    public string Stromerzeugung => Value;
    public string Installiert { get; }
    public string DisplayName { get; }

    private EnergieartTypes(string stromerzeugung, string installiert, string displayName) : base(stromerzeugung)
    {
        Installiert = installiert;
        DisplayName = displayName;
    }

    public static readonly EnergieartTypes Braunkohle = new("1223", "4072", "Braunkohle");
    public static readonly EnergieartTypes Kernenergie = new("1224", "4073", "Kernenergie");
    public static readonly EnergieartTypes WindOffshore = new("1225", "4076", "Wind (Offshore)");
    public static readonly EnergieartTypes Wasserkraft = new("1226", "3792", "Wasserkraft");
    public static readonly EnergieartTypes SonstigeKonventionelle = new("1227", "207", "Sonstige konventionelle");
    public static readonly EnergieartTypes SonstigeErneuerbare = new("1228", "194", "Sonstige erneuerbare");
    public static readonly EnergieartTypes Biomasse = new("4066", "189", "Biomasse");
    public static readonly EnergieartTypes WindOnshore = new("4067", "186", "Wind (Festland)");
    public static readonly EnergieartTypes Photovoltaik = new("4068", "188", "Photovoltaik");
    public static readonly EnergieartTypes Steinkohle = new("4069", "4075", "Steinkohle");
    public static readonly EnergieartTypes Pumpspeicher = new("4070", "4074", "Pumpspeicher");
    public static readonly EnergieartTypes Erdgas = new("4071", "198", "Erdgas");

    public static IReadOnlyList<EnergieartTypes> Values => new[]
    {
        Braunkohle, Kernenergie, WindOffshore, Wasserkraft, SonstigeKonventionelle, SonstigeErneuerbare,
        Biomasse, WindOnshore, Photovoltaik, Steinkohle, Pumpspeicher, Erdgas
    };
}
