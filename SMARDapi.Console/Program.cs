using SMARDapi;
using SMARDapi.Marktpreis;
using SMARDapi.Models;
using SMARDapi.Models.FilterTypes;
using SMARDapi.Stromerzeugung;

var smardRegionType = Regions.DE;
var smardResolutionType = Resolutions.Hour;
{
    var httpClient = new HttpClient();
    var apiClient = new SmardMarktpreisApi(httpClient);

    try
    {
        // Get index chart data for Germany at hourly resolution for the last month
        var smardMarktpreisFilterType = MarktpreisTypes.DeutschlandLuxemburg;
        var indexChartData = await apiClient.GetIndexChartData(smardRegionType, smardResolutionType, smardMarktpreisFilterType);
        Console.WriteLine(indexChartData);

        // Get quarter-hour table data for Germany for a specific timestamp
        var timestamp = indexChartData.Timestamps.Last();
        // Get table data for Germany for a specific timestamp
        var tableData = await apiClient.GetChartData(smardRegionType, smardMarktpreisFilterType, smardResolutionType, timestamp);
        Console.WriteLine(tableData);
    }
    catch (HttpRequestException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

}
{
    var httpClient = new HttpClient();
    var apiClient = new SmardEnergieartApi(httpClient);

    try
    {
        // Get index chart data for Germany at hourly resolution for the last month
        var smardEnergieartFilterType = EnergieartTypes.WindOffshore;
        var indexChartData = await apiClient.GetIndexChartData(smardRegionType, smardResolutionType, smardEnergieartFilterType);
        Console.WriteLine(indexChartData);

        // Get chart data for Germany at hourly resolution for the last month
        var timestamp = indexChartData.Timestamps.Last();
        var chartData = await apiClient.GetChartData(smardRegionType, smardEnergieartFilterType, smardResolutionType, timestamp);
        Console.WriteLine(chartData);

        // Get quarter-hour table data for Germany for a specific timestamp
        var quarterHourTableData = await apiClient.GetTableData(smardRegionType, smardEnergieartFilterType, timestamp);
        Console.WriteLine(quarterHourTableData);
    }
    catch (HttpRequestException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}