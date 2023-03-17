using SMARDapi.Marktpreis;
using SMARDapi.Models;
using SMARDapi.Models.FilterTypes;

namespace SMARDapi.Prognose;

/// <summary>
/// Represents the SMARD (Strommarktdaten) Prognose API.
/// </summary>
public class SmardPrognoseApi : SmardApiBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SmardPrognoseApi"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client to be used for API calls.</param>
    public SmardPrognoseApi(HttpClient httpClient) : base(httpClient)
    {
    }

    /// <summary>
    /// Retrieves index chart data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <param name="filter">The Prognose filter type.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the index chart data or null if not available.</returns>
    public async Task<IndexChartData?> GetIndexChartData(SmardRegionType region, SmardResolutionType resolution, SmardPrognoseFilterType filter)
    {
        return await GetIndexChartDataInternal(region, resolution, filter);
    }

    /// <summary>
    /// Retrieves chart data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="filter">The Prognose filter type.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <param name="timestamp">The date and time for the requested data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the chart data.</returns>
    public async Task<ChartResult> GetChartData(SmardRegionType region, SmardPrognoseFilterType filter, SmardResolutionType resolution, SmardTimestamp timestamp)
    {
        return await GetChartDataInternal(region, filter, resolution, timestamp);
    }

    /// <summary>
    /// Retrieves table data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="filter">The Prognose filter type.</param>
    /// <param name="timestamp">The date and time for the requested data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the table data.</returns>
    public async Task<TableResult> GetTableData(SmardRegionType region, SmardPrognoseFilterType filter, SmardTimestamp timestamp)
    {
        return await GetTableDataInternal(region, filter, timestamp);
    }
}
