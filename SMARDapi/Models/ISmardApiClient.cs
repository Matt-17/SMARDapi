using SMARDapi.Models.FilterTypes;

namespace SMARDapi.Models;

/// <summary>
/// 
/// </summary>
public interface ISmardApiClient : IDisposable
{

    /// <summary>
    /// Retrieves index chart data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <param name="filter">The Marktpreis filter type.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the index chart data or null if not available.</returns>
    Task<IndexChartData?> GetMarktpreisIndexChartData(Regions region, Resolutions resolution, MarktpreisTypes filter);

    /// <summary>
    /// Retrieves chart data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="filter">The Marktpreis filter type.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <param name="dateTime">The date and time for the requested data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the chart data.</returns>
    Task<ChartResult> GetMarktpreisChartData(Regions region, MarktpreisTypes filter, Resolutions resolution, SmardTimestamp dateTime);

    /// <summary>
    /// Retrieves index chart data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <param name="filter">The Prognose filter type.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the index chart data or null if not available.</returns>
    Task<IndexChartData?> GetPrognoseIndexChartData(Regions region, Resolutions resolution, PrognoseTypes filter);

    /// <summary>
    /// Retrieves chart data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="filter">The Prognose filter type.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <param name="timestamp">The date and time for the requested data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the chart data.</returns>
    Task<ChartResult> GetPrognoseChartData(Regions region, PrognoseTypes filter, Resolutions resolution, SmardTimestamp timestamp);

    /// <summary>
    /// Retrieves table data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="filter">The Prognose filter type.</param>
    /// <param name="timestamp">The date and time for the requested data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the table data.</returns>
    Task<TableResult> GetPrognoseTableData(Regions region, PrognoseTypes filter, SmardTimestamp timestamp);

    /// <summary>
    /// Retrieves index chart data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <param name="filter">The Energieart filter type.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the index chart data or null if not available.</returns>
    Task<IndexChartData?> GetEnergieartIndexChartData(Regions region, Resolutions resolution, EnergieartTypes filter);

    /// <summary>
    /// Retrieves chart data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="filter">The Energieart filter type.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <param name="timestamp">The date and time for the requested data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the chart data.</returns>
    Task<ChartResult> GetEnergieartChartData(Regions region, EnergieartTypes filter, Resolutions resolution, SmardTimestamp timestamp);

    /// <summary>
    /// Retrieves table data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="filter">The Energieart filter type.</param>
    /// <param name="timestamp">The date and time for the requested data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the table data as a string.</returns>
    Task<TableResult> GetEnergieartTableData(Regions region, EnergieartTypes filter, SmardTimestamp timestamp);
}