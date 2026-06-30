using System.Net;
using System.Net.Http;
using System.Text.Json;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

using SMARDapi.Models.FilterTypes;
using SMARDapi.Models.Internal;

namespace SMARDapi.Models;

/// <summary>
/// Client for direct access to the SMARD API endpoints.
/// </summary>
public sealed class SmardApiClient : ISmardApiClient
{
    private readonly ILogger _logger;
    internal const string BaseUrl = "https://www.smard.de/app/";

    private HttpClient HttpClient { get; }

    /// <summary>
    /// Creates a new client using the provided HTTP client and logger factory.
    /// </summary>
    /// <param name="httpClient">The HTTP client used for requests.</param>
    /// <param name="loggerFactory">The logger factory used for diagnostics.</param>
    public SmardApiClient(HttpClient httpClient, ILoggerFactory loggerFactory)
    {
        HttpClient = httpClient;
        HttpClient.BaseAddress = new Uri(BaseUrl);
        _logger = loggerFactory.CreateLogger<SmardApiClient>();
    }

    /// <summary>
    /// Creates a new client using the provided HTTP client.
    /// </summary>
    /// <param name="httpClient">The HTTP client used for requests.</param>
    public SmardApiClient(HttpClient httpClient) : this(httpClient, NullLoggerFactory.Instance)
    {
    }

    /// <summary>
    /// Creates a new client using the provided logger factory.
    /// </summary>
    /// <param name="loggerFactory">The logger factory used for diagnostics.</param>
    public SmardApiClient(ILoggerFactory loggerFactory) : this(new HttpClient(), loggerFactory)
    {
    }

    /// <summary>
    /// Creates a new client using default dependencies.
    /// </summary>
    public SmardApiClient() : this(new HttpClient(), NullLoggerFactory.Instance)
    {
    }

    /// <inheritdoc/>
    public Task<IndexChartData> GetMarktpreisIndexChartData(Regions region, Resolutions resolution, MarktpreisTypes filter, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("GetMarktpreisIndexChartData({region}, {resolution}, {filter})", region, resolution, filter);
        return GetIndexChartDataInternal(region, resolution, filter.ToString(), cancellationToken);
    }

    /// <inheritdoc/>
    public Task<ChartResult> GetMarktpreisChartData(Regions region, MarktpreisTypes filter, Resolutions resolution, SmardTimestamp dateTime, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("GetMarktpreisChartData({region}, {filter}, {resolution}, {dateTime})", region, filter, resolution, dateTime);
        return GetChartDataInternal(region, filter.ToString(), resolution, dateTime, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<IndexChartData> GetPrognoseIndexChartData(Regions region, Resolutions resolution, PrognoseTypes filter, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("GetPrognoseIndexChartData({region}, {resolution}, {filter})", region, resolution, filter);
        return GetIndexChartDataInternal(region, resolution, filter.ToString(), cancellationToken);
    }

    /// <inheritdoc/>
    public Task<ChartResult> GetPrognoseChartData(Regions region, PrognoseTypes filter, Resolutions resolution, SmardTimestamp timestamp, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("GetPrognoseChartData({region}, {filter}, {resolution}, {timestamp})", region, filter, resolution, timestamp);
        return GetChartDataInternal(region, filter.ToString(), resolution, timestamp, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<TableResult> GetPrognoseTableData(Regions region, PrognoseTypes filter, SmardTimestamp timestamp, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("GetPrognoseTableData({region}, {filter}, {timestamp})", region, filter, timestamp);
        return GetTableDataInternal(region, filter, timestamp, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<IndexChartData> GetEnergieartIndexChartData(Regions region, Resolutions resolution, EnergieartTypes filter, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("GetEnergieartIndexChartData({region}, {resolution}, {filter})", region, resolution, filter);
        return GetIndexChartDataInternal(region, resolution, filter.Stromerzeugung, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<ChartResult> GetEnergieartChartData(Regions region, EnergieartTypes filter, Resolutions resolution, SmardTimestamp timestamp, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("GetEnergieartChartData({region}, {filter}, {resolution}, {timestamp})", region, filter, resolution, timestamp);
        return GetChartDataInternal(region, filter.Stromerzeugung, resolution, timestamp, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<TableResult> GetEnergieartTableData(Regions region, EnergieartTypes filter, SmardTimestamp timestamp, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("GetEnergieartTableData({region}, {filter}, {timestamp})", region, filter, timestamp);
        return GetTableDataInternal(region, filter, timestamp, cancellationToken);
    }

    /// <inheritdoc />
    public Task<IndexChartData> GetInstallierteLeistung(Regions region, Resolutions resolution, EnergieartTypes filter, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("GetInstallierteLeistung({region}, {resolution}, {filter})", region, resolution, filter);
        return GetIndexChartDataInternal(region, resolution, filter.Installiert, cancellationToken);
    }

    /// <inheritdoc />
    public Task<ChartResult> GetInstallierteLeistungChartData(Regions region, EnergieartTypes filter, Resolutions resolution, SmardTimestamp timestamp, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("GetInstallierteLeistungChartData({region}, {filter}, {resolution}, {timestamp})", region, filter, resolution, timestamp);
        return GetChartDataInternal(region, filter.Installiert, resolution, timestamp, cancellationToken);
    }

    private async Task<IndexChartData> GetIndexChartDataInternal(Regions region, Resolutions resolution, string filter, CancellationToken cancellationToken)
    {
        var endpoint = $"chart_data/{filter}/{region}/index_{resolution}.json";
        var json = await SendHttpGetRequest(endpoint, cancellationToken).ConfigureAwait(false);
        var chartData = Deserialize<IndexChartDataInternal>(json, endpoint, "index chart");

        _logger.LogTrace("GetIndexChartDataInternal({region}, {resolution}, {filter}) => {chartData}", region, resolution, filter, chartData);

        return new IndexChartData(chartData);
    }

    private async Task<ChartResult> GetChartDataInternal(Regions region, string filter, Resolutions resolution, SmardTimestamp timestamp, CancellationToken cancellationToken)
    {
        var endpoint = $"chart_data/{filter}/{region}/{filter}_{region}_{resolution}_{timestamp.Value}.json";
        var json = await SendHttpGetRequest(endpoint, cancellationToken).ConfigureAwait(false);
        var chartResultInternal = Deserialize<ChartResultInternal>(json, endpoint, "chart");
        var chartResult = new ChartResult(chartResultInternal);

        _logger.LogTrace("GetChartDataInternal({region}, {filter}, {resolution}, {timestamp}) => {chartResult}", region, filter, resolution, timestamp, chartResult);

        return chartResult;
    }

    private async Task<TableResult> GetTableDataInternal(Regions region, SmardFilterType filter, SmardTimestamp timestamp, CancellationToken cancellationToken)
    {
        var endpoint = $"table_data/{filter}/{region}/{filter}_{region}_quarterhour_{timestamp.Value}.json";
        var json = await SendHttpGetRequest(endpoint, cancellationToken).ConfigureAwait(false);
        var tableResultInternal = Deserialize<TableResultInternal>(json, endpoint, "table");
        var tableResult = new TableResult(tableResultInternal);

        _logger.LogTrace("GetTableDataInternal({region}, {filter}, {timestamp}) => {tableResult}", region, filter, timestamp, tableResult);

        return tableResult;
    }

    private static T Deserialize<T>(string json, string endpoint, string resultKind)
    {
        try
        {
            var result = JsonSerializer.Deserialize<T>(json);
            return result ?? throw new SmardApiException($"SMARD returned an empty {resultKind} response.", endpoint);
        }
        catch (JsonException ex)
        {
            throw new SmardApiException($"SMARD returned invalid {resultKind} JSON.", endpoint, innerException: ex);
        }
    }

    private async Task<string> SendHttpGetRequest(string endpoint, CancellationToken cancellationToken)
    {
        if (endpoint == null)
        {
            throw new ArgumentNullException(nameof(endpoint));
        }

        _logger.LogTrace("SendHttpGetRequest({endpoint})", endpoint);

        HttpResponseMessage response;
        try
        {
            response = await HttpClient.GetAsync(endpoint, cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (HttpRequestException ex)
        {
            throw new SmardApiException("SMARD request failed.", endpoint, innerException: ex);
        }

        _logger.LogTrace("SendHttpGetRequest({endpoint}) => {statusCode}", endpoint, response.StatusCode);

        if (!response.IsSuccessStatusCode)
        {
            throw new SmardApiException($"SMARD request failed with HTTP {(int)response.StatusCode} ({response.StatusCode}).", endpoint, response.StatusCode);
        }

        try
        {
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested();
            return content;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex) when (ex is IOException || ex is ObjectDisposedException)
        {
            throw new SmardApiException("Failed to read SMARD response content.", endpoint, response.StatusCode, ex);
        }
    }

    /// <inheritdoc />
    public void Dispose()
    {
        HttpClient.Dispose();
    }
}
