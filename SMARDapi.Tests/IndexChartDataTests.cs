using System.Text.Json;

using SMARDapi.Models;
using SMARDapi.Models.Internal;

namespace SMARDapi.Tests;
[TestClass]
public class IndexChartDataTests
{
    [TestMethod]
    public void IndexChartDataConstructor_WhenPassedValidIndexChartDataInternal_ShouldPopulateFieldsCorrectly()
    {
        // Arrange
        var json = @"
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

        var indexChartDataInternal = JsonSerializer.Deserialize<IndexChartDataInternal>(json);

        Assert.IsNotNull(indexChartDataInternal);

        // Act
        var indexChartData = new IndexChartData(indexChartDataInternal);

        // Assert
        CollectionAssert.AreEqual(new long[] { 1514761200000, 1546297200000, 1577833200000, 1609455600000, 1640991600000, 1672527600000 }, indexChartData.Timestamps.Select(t => t.Value).ToList());
    }
}
