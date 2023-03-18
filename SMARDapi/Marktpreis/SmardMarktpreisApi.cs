using SMARDapi.Models;
using SMARDapi.Models.FilterTypes;

namespace SMARDapi.Marktpreis;

/// <summary>
/// Represents the SMARD (Strommarktdaten) Marktpreis API.
/// </summary>
public class SmardMarktpreisApi : SmardApiBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SmardMarktpreisApi"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client to be used for API calls.</param>
    public SmardMarktpreisApi(HttpClient httpClient) : base(httpClient)
    {
    }

    /// <summary>
    /// Retrieves index chart data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <param name="filter">The Marktpreis filter type.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the index chart data or null if not available.</returns>
    public async Task<IndexChartData?> GetIndexChartData(Regions region, Resolutions resolution, MarktpreisTypes filter)
    {
        return await GetIndexChartDataInternal(region, resolution, filter);
    }

    /// <summary>
    /// Retrieves chart data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="filter">The Marktpreis filter type.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <param name="dateTime">The date and time for the requested data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the chart data.</returns>
    public async Task<ChartResult> GetChartData(Regions region, MarktpreisTypes filter, Resolutions resolution, SmardTimestamp dateTime)
    {
        return await GetChartDataInternal(region, filter, resolution, dateTime);
    }
}
