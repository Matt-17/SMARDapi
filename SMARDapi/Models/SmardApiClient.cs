using System.Runtime.CompilerServices;
using System.Text.Json;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

using SMARDapi.Models.FilterTypes;
using SMARDapi.Models.Internal;

namespace SMARDapi.Models;

/// <summary>                
/// SmardApiClient class to interact with the Smard API.
/// </summary>
public sealed class SmardApiClient : ISmardApiClient
{
    private readonly ILogger _logger;
    internal const string BaseUrl = "https://www.smard.de/app/";

    /// <summary>
    /// 
    /// </summary>
    private HttpClient HttpClient { get; }

    #region ctor

    /// <summary>
    /// Primary constructor that takes HttpClient and ILoggerFactory instances for initialization.
    /// </summary>
    /// <param name="httpClient">An instance of HttpClient.</param>
    /// <param name="loggerFactory">An instance of ILoggerFactory.</param>
    public SmardApiClient(HttpClient httpClient, ILoggerFactory loggerFactory)
    {
        HttpClient = httpClient;
        HttpClient.BaseAddress = new Uri(BaseUrl);
        _logger = loggerFactory.CreateLogger<SmardApiClient>();
    }

    /// <summary>
    /// Constructor for when only HttpClient is provided.
    /// </summary>
    /// <param name="httpClient">An instance of HttpClient.</param>
    public SmardApiClient(HttpClient httpClient) : this(httpClient, NullLoggerFactory.Instance)
    {
    }

    /// <summary>
    /// Constructor for when only ILoggerFactory is provided.
    /// </summary>
    /// <param name="loggerFactory">An instance of ILoggerFactory.</param>
    public SmardApiClient(ILoggerFactory loggerFactory) : this(new HttpClient(), loggerFactory)
    {
    }

    /// <summary>
    /// Default constructor which initializes the HttpClient and ILogger with default values.
    /// </summary>
    public SmardApiClient() : this(new HttpClient(), NullLoggerFactory.Instance)
    {
    }
    #endregion

    /// <inheritdoc/>
    public async Task<IndexChartData?> GetMarktpreisIndexChartData(Regions region, Resolutions resolution, MarktpreisTypes filter)
    {
        _logger.LogDebug("GetMarktpreisIndexChartData({region}, {resolution}, {filter})", region, resolution, filter);
        return await GetIndexChartDataInternal(region, resolution, filter);
    }

    /// <inheritdoc/>
    public async Task<ChartResult> GetMarktpreisChartData(Regions region, MarktpreisTypes filter, Resolutions resolution, SmardTimestamp dateTime)
    {
        _logger.LogDebug("GetMarktpreisChartData({region}, {filter}, {resolution}, {dateTime})", region, filter, resolution, dateTime);
        return await GetChartDataInternal(region, filter, resolution, dateTime);
    }

    /// <inheritdoc/>
    public async Task<IndexChartData?> GetPrognoseIndexChartData(Regions region, Resolutions resolution, PrognoseTypes filter)
    {
        _logger.LogDebug("GetPrognoseIndexChartData({region}, {resolution}, {filter})", region, resolution, filter);
        return await GetIndexChartDataInternal(region, resolution, filter);
    }

    /// <inheritdoc/>
    public async Task<ChartResult> GetPrognoseChartData(Regions region, PrognoseTypes filter, Resolutions resolution, SmardTimestamp timestamp)
    {
        _logger.LogDebug("GetPrognoseChartData({region}, {filter}, {resolution}, {timestamp})", region, filter, resolution, timestamp);
        return await GetChartDataInternal(region, filter, resolution, timestamp);
    }

    /// <inheritdoc/>
    public async Task<TableResult> GetPrognoseTableData(Regions region, PrognoseTypes filter, SmardTimestamp timestamp)
    {
        _logger.LogDebug("GetPrognoseTableData({region}, {filter}, {timestamp})", region, filter, timestamp);
        return await GetTableDataInternal(region, filter, timestamp);
    }

    /// <inheritdoc/>
    public async Task<IndexChartData?> GetEnergieartIndexChartData(Regions region, Resolutions resolution, EnergieartTypes filter)
    {
        _logger.LogDebug("GetEnergieartIndexChartData({region}, {resolution}, {filter})", region, resolution, filter);
        return await GetIndexChartDataInternal(region, resolution, filter);
    }

    /// <inheritdoc/>
    public async Task<ChartResult> GetEnergieartChartData(Regions region, EnergieartTypes filter, Resolutions resolution, SmardTimestamp timestamp)
    {
        _logger.LogDebug("GetEnergieartChartData({region}, {filter}, {resolution}, {timestamp})", region, filter, resolution, timestamp);
        return await GetChartDataInternal(region, filter, resolution, timestamp);
    }

    /// <inheritdoc/>
    public async Task<TableResult> GetEnergieartTableData(Regions region, EnergieartTypes filter, SmardTimestamp timestamp)
    {
        _logger.LogDebug("GetEnergieartTableData({region}, {filter}, {timestamp})", region, filter, timestamp);
        return await GetTableDataInternal(region, filter, timestamp);
    }
    #region Private methods

    private async Task<IndexChartData?> GetIndexChartDataInternal(Regions region, Resolutions resolution, SmardFilterType filter)
    {
        var endpoint = $"chart_data/{filter}/{region}/index_{resolution}.json";
        var jsonString = await SendHttpGetRequest(endpoint);

        var chartData = JsonSerializer.Deserialize<IndexChartDataInternal>(jsonString);

        _logger.LogTrace("GetIndexChartDataInternal({region}, {resolution}, {filter}) => {chartData}", region, resolution, filter, chartData);

        return chartData == null ? null : new IndexChartData(chartData);
    }

    private async Task<ChartResult> GetChartDataInternal(Regions region, SmardFilterType filter, Resolutions resolution, SmardTimestamp timestamp)
    {
        var endpoint = $"chart_data/{filter}/{region}/{filter}_{region}_{resolution}_{timestamp.Value}.json";
        var json = await SendHttpGetRequest(endpoint);

        if (json == null)
            throw new Exception();

        var chartResultInternal = JsonSerializer.Deserialize<ChartResultInternal>(json);

        if (chartResultInternal == null)
            throw new Exception();


        var chartResult = new ChartResult(chartResultInternal);

        _logger.LogTrace("GetChartDataInternal({region}, {filter}, {resolution}, {timestamp}) => {chartResult}", region, filter, resolution, timestamp, chartResult);

        return chartResult;
    }

    private async Task<TableResult> GetTableDataInternal(Regions region, SmardFilterType filter, SmardTimestamp timestamp)
    {

        var endpoint = $"table_data/{filter}/{region}/{filter}_{region}_quarterhour_{timestamp.Value}.json";
        var json = await SendHttpGetRequest(endpoint);
        if (json == null)
            throw new Exception();

        var chartResultInternal = JsonSerializer.Deserialize<TableResultInternal>(json);

        if (chartResultInternal == null)
            throw new Exception();

        var tableResult = new TableResult(chartResultInternal);

        _logger.LogTrace("GetTableDataInternal({region}, {filter}, {timestamp}) => {tableResult}", region, filter, timestamp, tableResult);

        return tableResult;
    }

    private async Task<string> SendHttpGetRequest(string endpoint)
    {
        if (endpoint == null)
            throw new ArgumentNullException(nameof(endpoint));
        _logger.LogTrace("SendHttpGetRequest({endpoint})", endpoint);
        var response = await HttpClient.GetAsync(endpoint);
        _logger.LogTrace("SendHttpGetRequest({endpoint}) => {statusCode}", endpoint, response.StatusCode);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    #endregion

    /// <inheritdoc />
    public void Dispose()
    {
        HttpClient.Dispose();
    }
}