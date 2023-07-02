using NSubstitute;

using SMARDapi.Models;
using SMARDapi.Models.FilterTypes;
using SMARDapi.Models.Internal;

namespace SMARDapi.Tests;
[TestClass]
public class SmardClientTests
{
    private ISmardApiClient _apiClient = null!;
    private SmardClient _client = null!;

    [TestInitialize]
    public void Init()
    {
        _apiClient = Substitute.For<ISmardApiClient>();
        _client = new SmardClient(_apiClient);
    }

    [TestMethod]
    public async Task GetEnergieartTableData_ValidFilter_ReturnsTableData()
    {
        // Arrange
        var filter = EnergieartTypes.Biomasse;
        var indexChartDataInternal = new IndexChartDataInternal { Timestamps = new[] { 1627855200000, 1628460000000, 1629064800000 } };
        var tableResultInternal = new TableResultInternal
        {
            MetaData = new MetaDataInternal
            {
                Version = 1,
                Created = 1627858357549
            },
            Series = new[]
            {
                new SeriesInternal
                {
                    Values = new[]
                    {
                        new ValueInternal
                        {
                            Timestamp = 1647817200000,
                            Versions = new[]
                            {
                                new VersionInternal
                                {
                                    Value = 1225,
                                    Name = null
                                }
                            }
                        }
                    }
                }
            }
        };

        _apiClient.GetEnergieartIndexChartData(Regions.DE, Resolutions.Hour, filter).Returns(new IndexChartData(indexChartDataInternal));
        _apiClient.GetEnergieartTableData(Regions.DE, filter, Arg.Any<SmardTimestamp>()).Returns(new TableResult(tableResultInternal));

        // Act
        var result = await _client.GetEnergieartTableData(filter);

        // Assert
        await _apiClient.Received(1).GetEnergieartIndexChartData(Regions.DE, Resolutions.Hour, filter);
        await _apiClient.Received(1).GetEnergieartTableData(Regions.DE, filter, Arg.Any<SmardTimestamp>());
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetPrognoseChartData_ValidFilter_ReturnsChartData()
    {
        // Arrange
        var filter = PrognoseTypes.Onshore;
        var resolution = Resolutions.Day;
        var indexChartDataInternal = new IndexChartDataInternal { Timestamps = new[] { 1627855200000, 1628460000000, 1629064800000 } };
        var chartResultInternal = new ChartResultInternal
        {
            MetaData = new MetaDataInternal
            {
                Version = 1,
                Created = 1627858357549
            },
            Series = new[]
            {
                new double[] { 1647817200000, 1225 }
            }
        };

        _apiClient.GetPrognoseIndexChartData(Regions.DE, resolution, filter).Returns(new IndexChartData(indexChartDataInternal));
        _apiClient.GetPrognoseChartData(Regions.DE, filter, resolution, Arg.Any<SmardTimestamp>()).Returns(new ChartResult(chartResultInternal));

        // Act
        var result = await _client.GetPrognoseChartData(filter, resolution);

        // Assert
        await _apiClient.Received(1).GetPrognoseIndexChartData(Regions.DE, resolution, filter);
        await _apiClient.Received(1).GetPrognoseChartData(Regions.DE, filter, resolution, Arg.Any<SmardTimestamp>());
        Assert.IsNotNull(result);
    }
}
