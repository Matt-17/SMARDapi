using System.Text.Json;

using SMARDapi.Models;
using SMARDapi.Models.Internal;

namespace SMARDapi.Tests;

[TestClass]
public class TableResultTests
{
    [TestMethod]
    public void TableResultConstructor_WhenPassedValidTableResultInternal_ShouldPopulateFieldsCorrectly()
    {
        // Arrange
        var json = @"
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

        var tableResultInternal = JsonSerializer.Deserialize<TableResultInternal>(json);

        Assert.IsNotNull(tableResultInternal);

        // Act
        var tableResult = new TableResult(tableResultInternal);

        // Assert
        Assert.AreEqual(1, tableResult.MetaData.Version);
        var series = tableResult.Series.Single();
        Assert.AreEqual(1514761200000, series.Timestamp.Value);
        Assert.AreEqual(293.25m, series.Value);
    }
}