using SMARDapi.Models;
using SMARDapi.Models.FilterTypes;

namespace SMARDapi.Tests;

[TestClass]
public class SmardApiSmokeTests
{
    [TestMethod]
    [TestCategory("Smoke")]
    public async Task EnergieartChartEndpoint_ReturnsCurrentData()
    {
        if (!SmokeTestsEnabled())
        {
            return;
        }

        using var client = new SmardApiClient();
        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(30));

        var index = await client.GetEnergieartIndexChartData(
            Regions.DE,
            Resolutions.Hour,
            EnergieartTypes.SonstigeKonventionelle,
            timeout.Token);

        Assert.IsTrue(index.Timestamps.Count > 0);

        var latestTimestamp = index.Timestamps.Last();
        var chart = await client.GetEnergieartChartData(
            Regions.DE,
            EnergieartTypes.SonstigeKonventionelle,
            Resolutions.Hour,
            latestTimestamp,
            timeout.Token);

        Assert.IsTrue(chart.Series.Count > 0);
    }

    [TestMethod]
    [TestCategory("Smoke")]
    public async Task InstallierteLeistungEndpoint_ReturnsCurrentData()
    {
        if (!SmokeTestsEnabled())
        {
            return;
        }

        using var client = new SmardApiClient();
        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(30));

        var index = await client.GetInstallierteLeistung(
            Regions.DE,
            Resolutions.Hour,
            EnergieartTypes.Braunkohle,
            timeout.Token);

        Assert.IsTrue(index.Timestamps.Count > 0);

        var latestTimestamp = index.Timestamps.Last();
        var chart = await client.GetInstallierteLeistungChartData(
            Regions.DE,
            EnergieartTypes.Braunkohle,
            Resolutions.Hour,
            latestTimestamp,
            timeout.Token);

        Assert.IsTrue(chart.Series.Count > 0);
    }

    private static bool SmokeTestsEnabled()
    {
        return string.Equals(
            Environment.GetEnvironmentVariable("SMARDAPI_RUN_SMOKE_TESTS"),
            "1",
            StringComparison.Ordinal);
    }
}
