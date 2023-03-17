using SMARDapi.Filter;

namespace SMARDapi;

public class SmardPrognoseApi : SmardApiBase
{
    public SmardPrognoseApi(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<IndexChartData?> GetIndexChartData(SmardRegionType region, SmardResolutionType resolution, SmardPrognoseFilterType filter)
    {
        return await GetIndexChartDataInternal(region, resolution, filter);
    }

    public async Task<ChartResult> GetChartData(SmardRegionType region, SmardPrognoseFilterType filter, SmardResolutionType resolution, SmardTimestamp timestamp)
    {
        return await GetChartDataInternal(region, filter, resolution, timestamp);
    }

    public async Task<TableResult> GetTableData(SmardRegionType region, SmardPrognoseFilterType filter, SmardTimestamp timestamp)
    {
        return await GetTableDataInternal(region, filter, timestamp);
    }
}