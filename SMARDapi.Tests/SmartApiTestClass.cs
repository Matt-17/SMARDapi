using RichardSzalay.MockHttp;

using SMARDapi.Models;
using SMARDapi.Models.FilterTypes;

namespace SMARDapi.Tests;

[TestClass]
public class SmartApiTestClass
{
    private SmardApiClient _client = null!;
    private MockHttpMessageHandler _httpMock = null!;

    [TestInitialize]
    public void Init()
    {
        _httpMock = new MockHttpMessageHandler();

        var _httpClient = new HttpClient(_httpMock);

        _client = new SmardApiClient(_httpClient);
    }

    [TestMethod]
    public async Task TestMarktpreisIndexChartData()
    {
        // Arrange       
        const string response = @"
{
    ""timestamps"": [
        1514761200000,
        1546297200000,
        1577833200000,
        1609455600000,
        1640991600000,
        1672527600000
    ]
}
        ";

        var apiUrl = GetApiUrl("chart_data/4169/DE/index_day.json");
        _httpMock.When(apiUrl).Respond("application/json", response); // Respond with JSON

        // Act
        var result = await _client.GetMarktpreisIndexChartData(Regions.DE, Resolutions.Day, MarktpreisTypes.DeutschlandLuxemburg);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(6, result.Timestamps.Count);
        Assert.AreEqual(1514761200000, result.Timestamps[0].Value);
        Assert.AreEqual(1672527600000, result.Timestamps[5].Value);
    }

    [TestMethod]
    public async Task TestMarktpreisChartData()
    {
        // Arrange
        const string response = @"
    {
        ""meta_data"": {
            ""version"": 1,
            ""created"": 1514761200000
        },
        ""series"": [
            [1514761200000, 123.4],
            [1546297200000, 234.5]
        ]
    }
    ";

        var apiUrl = GetApiUrl("chart_data/4169/DE/4169_DE_day_1514761200000.json");
        _httpMock.When(apiUrl).Respond("application/json", response); // Respond with JSON

        var timestamp = new SmardTimestamp(1514761200000);

        // Act
        var result = await _client.GetMarktpreisChartData(Regions.DE, MarktpreisTypes.DeutschlandLuxemburg, Resolutions.Day, timestamp);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.MetaData.Version);
        Assert.AreEqual(2, result.Series.Count);
        Assert.AreEqual(1514761200000, result.Series[0].Timestamp.Value);
        Assert.AreEqual(123.4m, result.Series[0].Value);
        Assert.AreEqual(1546297200000, result.Series[1].Timestamp.Value);
        Assert.AreEqual(234.5m, result.Series[1].Value);
    }

    [TestMethod]
    public async Task TestPrognoseIndexChartData()
    {
        // Arrange       
        const string response = @"
    {
        ""timestamps"": [
            1514761200000,
            1546297200000,
            1577833200000,
            1609455600000,
            1640991600000,
            1672527600000
        ]
    }
    ";

        var apiUrl = GetApiUrl("chart_data/122/DE/index_day.json");
        _httpMock.When(apiUrl).Respond("application/json", response); // Respond with JSON

        // Act
        var result = await _client.GetPrognoseIndexChartData(Regions.DE, Resolutions.Day, PrognoseTypes.Gesamt);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(6, result.Timestamps.Count);
        Assert.AreEqual(1514761200000, result.Timestamps[0].Value);
        Assert.AreEqual(1672527600000, result.Timestamps[5].Value);
    }

  

    [TestMethod]
    public async Task TestGetPrognoseTableData()
    {
        // Arrange
        const string response = @"
    {
        ""meta_data"": {
            ""version"": 1,
            ""created"": 1514761200000
        },
        ""series"": [
            {
                ""values"": [
                    {
                        ""timestamp"": 1514761200000,
                        ""versions"": [
                            {
                                ""value"": 123.4,
                                ""name"": null
                            }
                        ]
                    },
                    {
                        ""timestamp"": 1546297200000,
                        ""versions"": [
                            {
                                ""value"": 234.5,
                                ""name"": null
                            }
                        ]
                    },
                    {
                        ""timestamp"": 1577833200000,
                        ""versions"": [
                            {
                                ""value"": null,
                                ""name"": null
                            }
                        ]
                    }
                ]
            }
        ]
    }
    ";

        var apiUrl = GetApiUrl("table_data/122/DE/122_DE_quarterhour_1514761200000.json");
        _httpMock.When(apiUrl).Respond("application/json", response); // Respond with JSON

        var timestamp = new SmardTimestamp(1514761200000);

        // Act
        var result = await _client.GetPrognoseTableData(Regions.DE, PrognoseTypes.Gesamt, timestamp);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.MetaData.Version);
        Assert.AreEqual(3, result.Series.Count);
        Assert.AreEqual(1514761200000, result.Series[0].Timestamp.Value);
        Assert.AreEqual(123.4m, result.Series[0].Value);
        Assert.AreEqual(1546297200000, result.Series[1].Timestamp.Value);
        Assert.AreEqual(234.5m, result.Series[1].Value);
        Assert.AreEqual(1577833200000, result.Series[2].Timestamp.Value);
        Assert.IsNull(result.Series[2].Value);
    }


    [TestMethod]
    public async Task TestGetEnergieartIndexChartData()
    {
        // Arrange       
        const string response = @"
{
    ""timestamps"": [
        1514761200000,
        1546297200000,
        1577833200000,
        1609455600000,
        1640991600000,
        1672527600000
    ]
}
";

        var apiUrl = GetApiUrl("chart_data/1227/DE/index_day.json");
        _httpMock.When(apiUrl).Respond("application/json", response); // Respond with JSON

        // Act
        var result = await _client.GetEnergieartIndexChartData(Regions.DE, Resolutions.Day, EnergieartTypes.SonstigeKonventionelle);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(6, result.Timestamps.Count);
        Assert.AreEqual(1514761200000, result.Timestamps[0].Value);
        Assert.AreEqual(1672527600000, result.Timestamps[5].Value);
    }

    [TestMethod]
    public async Task TestGetEnergieartChartData()
    {
        // Arrange
        const string response = @"
    {
        ""meta_data"": {
            ""version"": 1,
            ""created"": 1514761200000
        },
        ""series"": [
            [1514761200000, 123.4],
            [1546297200000, 234.5]
        ]
    }
    ";

        var apiUrl = GetApiUrl("chart_data/1227/DE/1227_DE_day_1514761200000.json");
        _httpMock.When(apiUrl).Respond("application/json", response); // Respond with JSON

        var timestamp = new SmardTimestamp(1514761200000);

        // Act
        var result = await _client.GetEnergieartChartData(Regions.DE, EnergieartTypes.SonstigeKonventionelle, Resolutions.Day, timestamp);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.MetaData.Version);
        Assert.AreEqual(2, result.Series.Count);
        Assert.AreEqual(1514761200000, result.Series[0].Timestamp.Value);
        Assert.AreEqual(123.4m, result.Series[0].Value);
        Assert.AreEqual(1546297200000, result.Series[1].Timestamp.Value);
        Assert.AreEqual(234.5m, result.Series[1].Value);
    }

    [TestMethod]
    public async Task TestGetEnergieartTableData()
    {
        // Arrange
        const string response = @"
    {
        ""meta_data"": {
            ""version"": 1,
            ""created"": 1670008108741
        },
        ""series"": [
            {
                ""values"": [
                    {
                        ""timestamp"": 1514761200000,
                        ""versions"": [
                            {
                                ""value"": 293.25,
                                ""name"": null
                            }
                        ]
                    }
                ]
            }
        ]
    }
    ";

        var apiUrl = GetApiUrl("table_data/1227/DE/1227_DE_quarterhour_1514761200000.json");
        _httpMock.When(apiUrl).Respond("application/json", response); // Respond with JSON

        var timestamp = new SmardTimestamp(1514761200000);

        // Act
        var result = await _client.GetEnergieartTableData(Regions.DE, EnergieartTypes.SonstigeKonventionelle, timestamp);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.MetaData.Version);
        Assert.AreEqual(1, result.Series.Count);

        var firstSeries = result.Series.First();
        Assert.AreEqual(1514761200000, firstSeries.Timestamp.Value);
        Assert.AreEqual(293.25m, firstSeries.Value);
    }


    [TestCleanup]
    public void Cleanup()
    {
        // Cleanup code after test method did execute
    }

    private static string GetApiUrl(string path)
    {
        return SmardApiClient.BaseUrl + path;
    }
}