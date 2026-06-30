using SMARDapi.Models.FilterTypes;

namespace SMARDapi.Models;

/// <summary>
/// Convenience client for retrieving the latest SMARD data for Germany.
/// </summary>
public interface ISmardClient : IDisposable
{
    /// <summary>
    /// Gets the latest table data for the specified generation type.
    /// </summary>
    /// <param name="filter">The generation type filter.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task whose result contains the table data.</returns>
    Task<TableResult> GetEnergieartTableData(EnergieartTypes filter, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the latest chart data for the specified generation type using hourly resolution.
    /// </summary>
    /// <param name="filter">The generation type filter.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task whose result contains the chart data.</returns>
    Task<ChartResult> GetEnergieartChartData(EnergieartTypes filter, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the latest chart data for the specified generation type and resolution.
    /// </summary>
    /// <param name="filter">The generation type filter.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task whose result contains the chart data.</returns>
    Task<ChartResult> GetEnergieartChartData(EnergieartTypes filter, Resolutions resolution, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the latest prognosis table data for the specified filter.
    /// </summary>
    /// <param name="filter">The prognosis filter type.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task whose result contains the table data.</returns>
    Task<TableResult> GetPrognoseTableData(PrognoseTypes filter, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the latest prognosis chart data for the specified filter and resolution.
    /// </summary>
    /// <param name="filter">The prognosis filter type.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task whose result contains the chart data.</returns>
    Task<ChartResult> GetPrognoseChartData(PrognoseTypes filter, Resolutions resolution, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the latest installed generation capacity chart data for the specified generation type.
    /// </summary>
    /// <param name="filter">The generation type filter.</param>
    /// <param name="cancellationToken">A token to cancel the request.</param>
    /// <returns>A task whose result contains the chart data.</returns>
    Task<ChartResult> GetInstallierteLeistung(EnergieartTypes filter, CancellationToken cancellationToken = default);
}
