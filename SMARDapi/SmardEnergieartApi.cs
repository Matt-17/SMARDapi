using SMARDapi.Filter;

namespace SMARDapi;

public class SmardEnergieartApi : SmardApiBase
{
    public SmardEnergieartApi(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<IndexChartData?> GetIndexChartData(SmardRegionType region, SmardResolutionType resolution, SmardEnergieartFilterType filter)
    {
        return await GetIndexChartDataInternal(region, resolution, filter);
    }

    public async Task<ChartResult> GetChartData(SmardRegionType region, SmardEnergieartFilterType filter, SmardResolutionType resolution, SmardTimestamp timestamp)
    {
        return await GetChartDataInternal(region, filter, resolution, timestamp);
    }

    public async Task<string> GetTableData(SmardRegionType region, SmardEnergieartFilterType filter, SmardTimestamp timestamp)
    {
        var endpoint = $"table_data/{filter}/{region}/{filter}_{region}_quarterhour_{timestamp}.json";
        return await SendHttpGetRequest(endpoint);
    }
}