using SMARDapi.Filter;

namespace SMARDapi;

public class SmardMarktpreisApi : SmardApiBase
{
    public SmardMarktpreisApi(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<string> GetIndexChartData(SmardRegionType region, SmardResolutionType resolution, SmardMarktpreisFilterType filter)
    {
        var endpoint = $"chart_data/{filter}/{region}/{resolution}.json";
        return await SendHttpGetRequest(endpoint);
    }

    public async Task<string> GetChartData(SmardRegionType region, SmardMarktpreisFilterType filter, SmardRegionType regionCopy, SmardMarktpreisFilterType filterCopy, SmardResolutionType resolution, long timestamp)
    {
        var endpoint = $"chart_data/{filter}/{region}/{filterCopy}_{regionCopy}_{resolution}_{timestamp}.json";
        return await SendHttpGetRequest(endpoint);
    }

    public async Task<string> GetQuarterHourTableData(SmardRegionType region, SmardMarktpreisFilterType filter, SmardRegionType regionCopy, SmardMarktpreisFilterType filterCopy, long timestamp)
    {
        var endpoint = $"table_data/{filter}/{region}/{filterCopy}_{regionCopy}_quarterhour_{timestamp}.json";
        return await SendHttpGetRequest(endpoint);
    }

    public async Task<string> GetTableData(SmardRegionType region, SmardMarktpreisFilterType filter, SmardRegionType regionCopy, SmardMarktpreisFilterType filterCopy, long timestamp)
    {
        var endpoint = $"table_data/{filter}/{region}/{filterCopy}_{regionCopy}_{timestamp}.json";
        return await SendHttpGetRequest(endpoint);
    }
}