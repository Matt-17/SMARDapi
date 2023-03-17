using System.Text.Json;
using SMARDapi.Marktpreis;
using SMARDapi.Models.FilterTypes;
using SMARDapi.Models.Internal;
using SMARDapi.Prognose;
using SMARDapi.Stromverbrauch;

namespace SMARDapi.Models;

public abstract class SmardApiBase
{
    private readonly string _baseUrl = "https://www.smard.de/app/";
    private readonly HttpClient _httpClient;

    protected SmardApiBase(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    protected async Task<IndexChartData?> GetIndexChartDataInternal(SmardRegionType region, SmardResolutionType resolution, SmardFilterType filter)
    {
        var endpoint = $"chart_data/{filter}/{region}/index_{resolution}.json";
        var jsonString = await SendHttpGetRequest(endpoint);

        var chartData = JsonSerializer.Deserialize<IndexChartDataInternal>(jsonString);

        return chartData == null ? null : new IndexChartData(chartData.timestamps);
    }

    protected async Task<ChartResult> GetChartDataInternal(SmardRegionType region, SmardFilterType filter, SmardResolutionType resolution, SmardTimestamp dateTime)
    {
        var timestamp = dateTime.Timestamp;

        var endpoint = $"chart_data/{filter}/{region}/{filter}_{region}_{resolution}_{timestamp}.json";
        var json = await SendHttpGetRequest(endpoint);

        if (json == null)
            throw new Exception();

        var chartResultInternal = JsonSerializer.Deserialize<ChartResultInternal>(json);

        if (chartResultInternal == null)
            throw new Exception();


        var chartResult = new ChartResult(chartResultInternal);


        return chartResult;
    }

    protected async Task<TableResult> GetTableDataInternal(SmardRegionType region, SmardPrognoseFilterType filter, SmardTimestamp timestamp)
    {
        var endpoint = $"table_data/{filter}/{region}/{filter}_{region}_quarterhour_{timestamp}.json";
        var json = await SendHttpGetRequest(endpoint);
        if (json == null)
            throw new Exception();

        var chartResultInternal = JsonSerializer.Deserialize<TableResultInternal>(json);

        if (chartResultInternal == null)
            throw new Exception();


        var tableResult = new TableResult(chartResultInternal);


        return tableResult;
    }

    protected async Task<string> SendHttpGetRequest(string endpoint)
    {
        var url = _baseUrl + endpoint;
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}