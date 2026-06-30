using SMARDapi.Models.FilterTypes;

namespace SMARDapi.Models;

/// <summary>
/// Client for direct access to SMARD API endpoints.
/// </summary>
public interface ISmardApiClient : IDisposable
{
    /// <summary>
    /// Retrieves market price index chart data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <param name="filter">The market price filter type.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task whose result contains the index chart data.</returns>
    Task<IndexChartData> GetMarktpreisIndexChartData(Regions region, Resolutions resolution, MarktpreisTypes filter, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves market price chart data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="filter">The market price filter type.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <param name="dateTime">The timestamp for the requested data.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task whose result contains the chart data.</returns>
    Task<ChartResult> GetMarktpreisChartData(Regions region, MarktpreisTypes filter, Resolutions resolution, SmardTimestamp dateTime, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves prognosis index chart data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <param name="filter">The prognosis filter type.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task whose result contains the index chart data.</returns>
    Task<IndexChartData> GetPrognoseIndexChartData(Regions region, Resolutions resolution, PrognoseTypes filter, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves prognosis chart data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="filter">The prognosis filter type.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <param name="timestamp">The timestamp for the requested data.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task whose result contains the chart data.</returns>
    Task<ChartResult> GetPrognoseChartData(Regions region, PrognoseTypes filter, Resolutions resolution, SmardTimestamp timestamp, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves prognosis table data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="filter">The prognosis filter type.</param>
    /// <param name="timestamp">The timestamp for the requested data.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task whose result contains the table data.</returns>
    Task<TableResult> GetPrognoseTableData(Regions region, PrognoseTypes filter, SmardTimestamp timestamp, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves generation type index chart data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <param name="filter">The generation type filter.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task whose result contains the index chart data.</returns>
    Task<IndexChartData> GetEnergieartIndexChartData(Regions region, Resolutions resolution, EnergieartTypes filter, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves generation type chart data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="filter">The generation type filter.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <param name="timestamp">The timestamp for the requested data.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task whose result contains the chart data.</returns>
    Task<ChartResult> GetEnergieartChartData(Regions region, EnergieartTypes filter, Resolutions resolution, SmardTimestamp timestamp, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves generation type table data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="filter">The generation type filter.</param>
    /// <param name="timestamp">The timestamp for the requested data.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task whose result contains the table data.</returns>
    Task<TableResult> GetEnergieartTableData(Regions region, EnergieartTypes filter, SmardTimestamp timestamp, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves installed generation capacity index chart data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <param name="filter">The generation type filter.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task whose result contains the index chart data.</returns>
    Task<IndexChartData> GetInstallierteLeistung(Regions region, Resolutions resolution, EnergieartTypes filter, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves installed generation capacity chart data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="filter">The generation type filter.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <param name="timestamp">The timestamp for the requested data.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task whose result contains the chart data.</returns>
    Task<ChartResult> GetInstallierteLeistungChartData(Regions region, EnergieartTypes filter, Resolutions resolution, SmardTimestamp timestamp, CancellationToken cancellationToken = default);
}
