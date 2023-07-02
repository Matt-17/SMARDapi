using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

using SMARDapi.Models.FilterTypes;

namespace SMARDapi.Models;

/// <summary>
/// Client for the SMARD (Strommarktdaten) API.
/// </summary>
public class SmardClient : ISmardClient
{
    private readonly ISmardApiClient _apiClient;
    private readonly ILogger<SmardClient> _logger;

    internal SmardClient(ISmardApiClient apiClient, ILoggerFactory loggerFactory)
    {
        _apiClient = apiClient;
        _logger = loggerFactory.CreateLogger<SmardClient>();
    }

    internal SmardClient(ISmardApiClient apiClient) : this(apiClient, NullLoggerFactory.Instance)
    {
    }

    /// <summary>
    /// Constructor for when only ILoggerFactory is provided.
    /// </summary>
    /// <param name="loggerFactory">ILoggerFactory</param>
    public SmardClient(ILoggerFactory loggerFactory) : this(new SmardApiClient(), loggerFactory)
    {
    }

    /// <summary>
    /// Default constructor which initializes the HttpClient and ILogger with default values.
    /// </summary>
    public SmardClient() : this(new SmardApiClient(), NullLoggerFactory.Instance)
    {
    }


    /// <inheritdoc />
    public async Task<TableResult> GetEnergieartTableData(EnergieartTypes filter)
    {
        _logger.LogDebug("GetEnergieartTableData({filter})", filter);
        var indexChartData = await _apiClient.GetEnergieartIndexChartData(Regions.DE, Resolutions.Hour, filter);
        var timestamp = indexChartData?.Timestamps.LastOrDefault();
        if (timestamp == null)
        {
            throw new Exception("Failed to retrieve index chart data or no timestamps available.");
        }
        return await _apiClient.GetEnergieartTableData(Regions.DE, filter, new SmardTimestamp(timestamp.Value));
    }

    /// <inheritdoc />
    public async Task<ChartResult> GetEnergieartChartData(EnergieartTypes filter, Resolutions resolution)
    {
        _logger.LogDebug("GetEnergieartChartData({filter}, {resolution})", filter, resolution);
        var indexChartData = await _apiClient.GetEnergieartIndexChartData(Regions.DE, resolution, filter);
        var timestamp = indexChartData?.Timestamps.LastOrDefault();
        if (timestamp == null)
        {
            throw new Exception("Failed to retrieve index chart data or no timestamps available.");
        }
        return await _apiClient.GetEnergieartChartData(Regions.DE, filter, resolution, new SmardTimestamp(timestamp.Value));
    }

    /// <inheritdoc />
    public async Task<TableResult> GetPrognoseTableData(PrognoseTypes filter)
    {
        _logger.LogDebug("GetPrognoseTableData({filter})", filter);
        var indexChartData = await _apiClient.GetPrognoseIndexChartData(Regions.DE, Resolutions.Hour, filter);
        var timestamp = indexChartData?.Timestamps.LastOrDefault();
        if (timestamp == null)
        {
            throw new Exception("Failed to retrieve index chart data or no timestamps available.");
        }
        return await _apiClient.GetPrognoseTableData(Regions.DE, filter, new SmardTimestamp(timestamp.Value));
    }

    /// <inheritdoc />
    public async Task<ChartResult> GetPrognoseChartData(PrognoseTypes filter, Resolutions resolution)
    {
        _logger.LogDebug("GetPrognoseChartData({filter}, {resolution})", filter, resolution);
        var indexChartData = await _apiClient.GetPrognoseIndexChartData(Regions.DE, resolution, filter);
        var timestamp = indexChartData?.Timestamps.LastOrDefault();
        if (timestamp == null)
        {
            throw new Exception("Failed to retrieve index chart data or no timestamps available.");
        }
        return await _apiClient.GetPrognoseChartData(Regions.DE, filter, resolution, new SmardTimestamp(timestamp.Value));
    }

    /// <inheritdoc />
    public void Dispose()
    {
        _apiClient.Dispose();
    }
}