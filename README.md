[![Master build](https://github.com/Matt-17/SMARDapi/actions/workflows/master.yml/badge.svg)](https://github.com/Matt-17/SMARDapi/actions/workflows/master.yml)
[![NuGet](https://img.shields.io/nuget/v/SMARDapi.svg)](https://www.nuget.org/packages/SMARDapi/)

# SMARDapi for .NET

SMARDapi is a small .NET client for publicly available SMARD (Strommarktdaten) data from the German Federal Network Agency (Bundesnetzagentur). It can retrieve chart and table data for electricity generation, forecasts, market prices, and installed generation capacity.

The library targets `netstandard2.0` and `net10.0`, so it can be used from modern .NET applications and older consumers that still depend on .NET Standard compatibility. The included console app targets `net10.0`.

## Features

- Retrieve SMARD chart index, chart, and table JSON data.
- Query by region, resolution, and SMARD filter type.
- Access electricity generation, forecasts, market prices, and installed capacity.
- Use a convenience client for latest German data or a direct API client for exact endpoints.
- Pass `CancellationToken` through all API calls.
- Handle API and JSON errors via `SmardApiException`.

## Installation

Install the [SMARDapi NuGet package](https://www.nuget.org/packages/SMARDapi/):

```powershell
dotnet add package SMARDapi
```

## Quick Start

Use `SmardClient` when you want the latest available German data without manually looking up the newest timestamp:

```csharp
using SMARDapi.Models;
using SMARDapi.Models.FilterTypes;

using var client = new SmardClient();

var photovoltaik = await client.GetEnergieartChartData(EnergieartTypes.Photovoltaik);
var latestValue = photovoltaik.Series.LastOrDefault(value => value.Value.HasValue);

Console.WriteLine($"{latestValue?.Timestamp}: {latestValue?.Value} MW");
```

Table data is available separately and returns a `TableResult`:

```csharp
using var client = new SmardClient();

var table = await client.GetEnergieartTableData(EnergieartTypes.WindOnshore);
var latest = table.Series.LastOrDefault(value => value.Value.HasValue);
```

Installed generation capacity can be queried through the same convenience client:

```csharp
using var client = new SmardClient();

var installedCapacity = await client.GetInstallierteLeistung(EnergieartTypes.Biomasse);
var latestCapacity = installedCapacity.Series.LastOrDefault(value => value.Value.HasValue);
```

## Direct API Access

Use `SmardApiClient` when you need exact control over region, resolution, filter, and timestamp:

```csharp
using SMARDapi.Models;
using SMARDapi.Models.FilterTypes;

using var client = new SmardApiClient();
using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(30));

var index = await client.GetMarktpreisIndexChartData(
    Regions.DE,
    Resolutions.Day,
    MarktpreisTypes.DeutschlandLuxemburg,
    timeout.Token);

var latestTimestamp = index.Timestamps.Last();

var chart = await client.GetMarktpreisChartData(
    Regions.DE,
    MarktpreisTypes.DeutschlandLuxemburg,
    Resolutions.Day,
    latestTimestamp,
    timeout.Token);
```

HTTP and JSON failures are reported as `SmardApiException`:

```csharp
try
{
    var result = await client.GetEnergieartChartData(
        Regions.DE,
        EnergieartTypes.Photovoltaik,
        Resolutions.Hour,
        latestTimestamp);
}
catch (SmardApiException ex)
{
    Console.WriteLine($"SMARD request failed for {ex.Endpoint}: {ex.Message}");
}
```

## Console App

The repository includes a small `net10.0` console app that renders current German production values as ASCII bars:

```powershell
dotnet run --project SMARDapi.Console
```

Watch mode refreshes automatically:

```powershell
dotnet run --project SMARDapi.Console -- --watch --interval=60
```

## Tests

Run the normal test suite:

```powershell
dotnet test SMARDapi.slnx --no-restore
```

Smoke tests call live SMARD endpoints and are disabled by default. Enable them explicitly:

```powershell
$env:SMARDAPI_RUN_SMOKE_TESTS = "1"
dotnet test SMARDapi.Tests\SMARDapi.Tests.csproj --filter TestCategory=Smoke
```

## Releases

NuGet package versions are derived from the git tag. Push tags such as `v1.0.7`; the release workflow strips the leading `v`, creates a GitHub Release, attaches the package, and publishes `SMARDapi` as version `1.0.7`.

NuGet publishing uses Trusted Publishing. Configure a nuget.org Trusted Publishing policy for `.github/workflows/release.yml` and set the GitHub repository variable `NUGET_USER` to the nuget.org username that created the policy.

Use an annotated tag if you want the tag message to become the GitHub Release notes:

```powershell
git tag -a v1.0.7 -m "SMARDapi 1.0.7"
git push origin v1.0.7
```

Do not update a version number in the project files for normal releases. For a local package build, pass the version explicitly:

```powershell
dotnet pack SMARDapi\SMARDapi.csproj -c Release -p:Version=1.0.7 -p:PackageVersion=1.0.7
```

## License

This library is open source and available under the MIT License.

## Disclaimer

This library is not affiliated with or endorsed by the Bundesnetzagentur or the official SMARD website. It is an independent implementation that accesses publicly available SMARD data.
