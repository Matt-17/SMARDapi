using SMARDapi.Marktpreis;
using SMARDapi.Models;
using SMARDapi.Models.FilterTypes;

namespace SMARDapi.Stromerzeugung;

/// <summary>
/// Represents the SMARD (Strommarktdaten) Energieart API.
/// </summary>
public class SmardEnergieartApi : SmardApiBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SmardEnergieartApi"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client to be used for API calls.</param>
    public SmardEnergieartApi(HttpClient httpClient) : base(httpClient)
    {
    }

    /// <summary>
    /// Retrieves index chart data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <param name="filter">The Energieart filter type.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the index chart data or null if not available.</returns>
    public async Task<IndexChartData?> GetIndexChartData(Regions region, Resolutions resolution, EnergieartTypes filter)
    {
        return await GetIndexChartDataInternal(region, resolution, filter);
    }

    /// <summary>
    /// Retrieves chart data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="filter">The Energieart filter type.</param>
    /// <param name="resolution">The time resolution of the data.</param>
    /// <param name="timestamp">The date and time for the requested data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the chart data.</returns>
    public async Task<ChartResult> GetChartData(Regions region, EnergieartTypes filter, Resolutions resolution, SmardTimestamp timestamp)
    {
        return await GetChartDataInternal(region, filter, resolution, timestamp);
    }

    /// <summary>
    /// Retrieves table data for the specified parameters.
    /// </summary>
    /// <param name="region">The region to filter the data by.</param>
    /// <param name="filter">The Energieart filter type.</param>
    /// <param name="timestamp">The date and time for the requested data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the table data as a string.</returns>
    public async Task<string> GetTableData(Regions region, EnergieartTypes filter, SmardTimestamp timestamp)
    {
        var endpoint = $"table_data/{filter}/{region}/{filter}_{region}_quarterhour_{timestamp}.json";
        return await SendHttpGetRequest(endpoint);
    }
}
