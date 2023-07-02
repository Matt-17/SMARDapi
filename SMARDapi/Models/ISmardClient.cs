using SMARDapi.Models.FilterTypes;

namespace SMARDapi.Models;

/// <summary>
/// SmardApiClient class to interact with the Smard API.
/// </summary>
public interface ISmardClient : IDisposable
{
    /// <summary>
    /// Get the table data for the specified Energieart.
    /// </summary>
    /// <param name="filter">The Energieart filter type.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the table data.</returns>
    Task<TableResult> GetEnergieartTableData(EnergieartTypes filter);

    /// <summary>
    /// Get the chart data for the specified Energieart.
    /// </summary>
    /// <param name="filter">The Energieart filter type.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the chart data.</returns>
    Task<ChartResult> GetEnergieartChartData(EnergieartTypes filter, Resolutions resolution);

    /// <summary>
    /// Get the table data for the specified Prognose.
    /// </summary>
    /// <param name="filter">The Prognose filter type.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the table data.</returns>
    Task<TableResult> GetPrognoseTableData(PrognoseTypes filter);

    /// <summary>
    /// Get the chart data for the specified Prognose.
    /// </summary>
    /// <param name="filter">The Prognose filter type.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the chart data.</returns>
    Task<ChartResult> GetPrognoseChartData(PrognoseTypes filter, Resolutions resolution);
}