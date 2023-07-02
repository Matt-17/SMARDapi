using System.Text.Json;

using SMARDapi.Models;
using SMARDapi.Models.Internal;

namespace SMARDapi.Tests;
[TestClass]
public class ChartResultTests
{
    [TestMethod]
    public void ChartResultConstructor_WhenPassedValidChartResultInternal_ShouldPopulateFieldsCorrectly()
    {
        // Arrange
        var json = @"
        {
            ""meta_data"": {
                ""version"": 1,
                ""created"": 1670008108741
            },
            ""series"": [
                [1514761200000, 123.4],
                [1546297200000, 234.5]
            ]
        }
        ";

        var chartResultInternal = JsonSerializer.Deserialize<ChartResultInternal>(json);

        Assert.IsNotNull(chartResultInternal);

        // Act
        var chartResult = new ChartResult(chartResultInternal);

        // Assert
        Assert.AreEqual(1, chartResult.MetaData.Version);
        Assert.AreEqual(2, chartResult.Series.Count);

        Assert.AreEqual(1514761200000, chartResult.Series[0].Timestamp.Value);
        Assert.AreEqual(123.4m, chartResult.Series[0].Value);

        Assert.AreEqual(1546297200000, chartResult.Series[1].Timestamp.Value);
        Assert.AreEqual(234.5m, chartResult.Series[1].Value);
    }
}