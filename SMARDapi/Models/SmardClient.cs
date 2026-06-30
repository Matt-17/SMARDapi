using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

using SMARDapi.Models.FilterTypes;

namespace SMARDapi.Models;

/// <summary>
/// Convenience client for retrieving the latest SMARD data for Germany.
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
    /// Creates a new client using the provided logger factory.
    /// </summary>
    /// <param name="loggerFactory">The logger factory used for diagnostics.</param>
    public SmardClient(ILoggerFactory loggerFactory) : this(new SmardApiClient(), loggerFactory)
    {
    }

    /// <summary>
    /// Creates a new client using default dependencies.
    /// </summary>
    public SmardClient() : this(new SmardApiClient(), NullLoggerFactory.Instance)
    {
    }

    /// <inheritdoc />
    public async Task<TableResult> GetEnergieartTableData(EnergieartTypes filter, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("GetEnergieartTableData({filter})", filter);
        var indexChartData = await _apiClient.GetEnergieartIndexChartData(Regions.DE, Resolutions.Hour, filter, cancellationToken).ConfigureAwait(false);
        var timestamp = GetLatestTimestamp(indexChartData, "Energieart table data");
        return await _apiClient.GetEnergieartTableData(Regions.DE, filter, timestamp, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public Task<ChartResult> GetEnergieartChartData(EnergieartTypes filter, CancellationToken cancellationToken = default)
    {
        return GetEnergieartChartData(filter, Resolutions.Hour, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<ChartResult> GetEnergieartChartData(EnergieartTypes filter, Resolutions resolution, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("GetEnergieartChartData({filter}, {resolution})", filter, resolution);
        var indexChartData = await _apiClient.GetEnergieartIndexChartData(Regions.DE, resolution, filter, cancellationToken).ConfigureAwait(false);
        var timestamp = GetLatestTimestamp(indexChartData, "Energieart chart data");
        return await _apiClient.GetEnergieartChartData(Regions.DE, filter, resolution, timestamp, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<TableResult> GetPrognoseTableData(PrognoseTypes filter, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("GetPrognoseTableData({filter})", filter);
        var indexChartData = await _apiClient.GetPrognoseIndexChartData(Regions.DE, Resolutions.Hour, filter, cancellationToken).ConfigureAwait(false);
        var timestamp = GetLatestTimestamp(indexChartData, "Prognose table data");
        return await _apiClient.GetPrognoseTableData(Regions.DE, filter, timestamp, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<ChartResult> GetPrognoseChartData(PrognoseTypes filter, Resolutions resolution, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("GetPrognoseChartData({filter}, {resolution})", filter, resolution);
        var indexChartData = await _apiClient.GetPrognoseIndexChartData(Regions.DE, resolution, filter, cancellationToken).ConfigureAwait(false);
        var timestamp = GetLatestTimestamp(indexChartData, "Prognose chart data");
        return await _apiClient.GetPrognoseChartData(Regions.DE, filter, resolution, timestamp, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<ChartResult> GetInstallierteLeistung(EnergieartTypes filter, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("GetInstallierteLeistung({filter})", filter);
        var indexChartData = await _apiClient.GetInstallierteLeistung(Regions.DE, Resolutions.Hour, filter, cancellationToken).ConfigureAwait(false);
        var timestamp = GetLatestTimestamp(indexChartData, "installierte Leistung");
        return await _apiClient.GetInstallierteLeistungChartData(Regions.DE, filter, Resolutions.Hour, timestamp, cancellationToken).ConfigureAwait(false);
    }

    private static SmardTimestamp GetLatestTimestamp(IndexChartData indexChartData, string operation)
    {
        var timestamp = indexChartData.Timestamps.LastOrDefault();
        if (timestamp == null)
        {
            throw new SmardApiException($"SMARD did not return any timestamps for {operation}.");
        }

        return timestamp;
    }

    /// <inheritdoc />
    public void Dispose()
    {
        _apiClient.Dispose();
    }
}
