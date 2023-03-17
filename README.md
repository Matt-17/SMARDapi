[![Master build](https://github.com/Matt-17/SMARDapi/actions/workflows/master.yml/badge.svg)](https://github.com/Matt-17/SMARDapi/actions/workflows/master.yml)
[![NuGet package build](https://github.com/Matt-17/SMARDapi/actions/workflows/release.yml/badge.svg)](https://github.com/Matt-17/SMARDapi/actions/workflows/release.yml)

# SMARDapi for .NET

This .NET library provides access to the SMARD (Strommarktdaten) API, an information platform by the German 
Federal Network Agency (Bundesnetzagentur) that offers comprehensive and up-to-date data on the German electricity 
market since 2017. The library enables developers to easily query and retrieve data related to electricity generation, 
consumption, market prices, and more.

## Features

- Access to various data categories, including electricity generation, consumption, market, and system stability.
- Query data by region and filter type.
- Choose between different time resolutions, such as hour, quarter-hour, day, week, month, and year.
- Retrieve data as charts, tables, or raw data in JSON format.

## Data Categories

The SMARD API provides access to the following data categories:

- Electricity Generation
  - Realized generation
  - Forecasted generation
  - Installed generation capacity
- Electricity Consumption
  - Realized consumption
  - Forecasted consumption
- Market
  - Wholesale prices
  - Commercial cross-border trade
  - Physical electricity flow

## Usage

1. Install the [SMARDapi NuGet package](https://www.nuget.org/packages/SMARDapi/) as a dependency in your .NET project.
2. Create instances of the `SmardApi` classes, such as `SmardMarktpreisApi`, `SmardPrognoseApi`, and `SmardEnergieartApi`.
3. Use the provided methods to query and retrieve data from the SMARD API.

## Examples

Here are some example usages of the library:

```csharp
// Initialize the API clients
var httpClient = new HttpClient();
var marktpreisApi = new SmardMarktpreisApi(httpClient);
var prognoseApi = new SmardPrognoseApi(httpClient);
var energieartApi = new SmardEnergieartApi(httpClient);

// Retrieve index chart data
var indexChartData = await marktpreisApi.GetIndexChartData(SmardRegionType.DE, SmardResolutionType.Day, SmardMarktpreisFilterType.AveragePrice);

// Retrieve chart data
var chartData = await marktpreisApi.GetChartData(SmardRegionType.DE, SmardMarktpreisFilterType.AveragePrice, SmardResolutionType.Day, new SmardTimestamp(DateTime.Now));

// Retrieve table data
var tableData = await prognoseApi.GetTableData(SmardRegionType.DE, SmardPrognoseFilterType.GenerationForecast, new SmardTimestamp(DateTime.Now));

// Retrieve raw JSON data for a specific filter
var rawData = await energieartApi.GetTableData(SmardRegionType.DE, SmardEnergieartFilterType.Photovoltaics, new SmardTimestamp(DateTime.Now));
```

For more examples and detailed documentation, please refer to the provided code snippets and XML comments in the library.

## License

This library is open source and available under the MIT License.

## Disclaimer

This library is not affiliated with or endorsed by the Bundesnetzagentur or the official SMARD website. It is an independent
implementation that accesses publicly available data from the SMARD API.