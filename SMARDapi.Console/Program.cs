using SMARDapi.CommandLine;
using SMARDapi.Models;
using SMARDapi.Models.FilterTypes;

var watch = args.Any(arg => string.Equals(arg, "--watch", StringComparison.OrdinalIgnoreCase));
var refreshInterval = GetRefreshInterval(args) ?? TimeSpan.FromMinutes(1);

using var client = new SmardClient();
using var cancellation = new CancellationTokenSource();

Console.CancelKeyPress += (_, eventArgs) =>
{
    eventArgs.Cancel = true;
    cancellation.Cancel();
};

try
{
    do
    {
        if (watch)
        {
            TryClearConsole();
        }

        await RenderSnapshot(client, cancellation.Token);

        if (!watch)
        {
            break;
        }

        Console.WriteLine();
        Console.WriteLine($"Next refresh: {DateTime.Now.Add(refreshInterval):HH:mm:ss}. Press Ctrl+C to stop.");
        await Task.Delay(refreshInterval, cancellation.Token);
    }
    while (!cancellation.IsCancellationRequested);

    return 0;
}
catch (OperationCanceledException)
{
    return 0;
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Error: {ex.Message}");
    return 1;
}

static async Task RenderSnapshot(SmardClient client, CancellationToken cancellationToken)
{
    Console.WriteLine($"SMARD energy production Germany ({DateTime.Now:yyyy-MM-dd HH:mm:ss})");
    Console.WriteLine();

    foreach (var energieart in EnergieartTypes.Values)
    {
        var row = await ReadEnergyRow(client, energieart, cancellationToken);
        if (row.ErrorMessage != null)
        {
            Console.WriteLine($"{FormatName(energieart.DisplayName)} unavailable: {row.ErrorMessage}");
            continue;
        }

        var maxValue = row.InstalledCapacity.GetValueOrDefault();
        if (maxValue <= 0)
        {
            maxValue = Math.Max(row.CurrentProduction, 1);
        }

        var bar = new AsciiBarGenerator(energieart.DisplayName, maxValue).GenerateAsciiBar(row.CurrentProduction);
        var valueText = row.InstalledCapacity is > 0
            ? $"{row.CurrentProduction,8:F0}/{row.InstalledCapacity.Value:F0} MW"
            : $"{row.CurrentProduction,8:F0} MW";

        Console.WriteLine($"{bar} {valueText}");
    }
}

static async Task<EnergyRow> ReadEnergyRow(SmardClient client, EnergieartTypes energieart, CancellationToken cancellationToken)
{
    try
    {
        var currentProduction = LastValue(await client.GetEnergieartChartData(energieart, cancellationToken));
        if (currentProduction == null)
        {
            return EnergyRow.Unavailable("No production value returned.");
        }

        var installedCapacity = LastValue(await client.GetInstallierteLeistung(energieart, cancellationToken));
        return new EnergyRow(currentProduction.Value, installedCapacity, null);
    }
    catch (Exception ex)
    {
        return EnergyRow.Unavailable(ex.Message);
    }
}

static decimal? LastValue(ChartResult result)
{
    return result.Series.LastOrDefault(value => value.Value.HasValue)?.Value;
}

static string FormatName(string name)
{
    return name.Length > AsciiBarGenerator.TitleLength
        ? name[..AsciiBarGenerator.TitleLength]
        : name.PadRight(AsciiBarGenerator.TitleLength);
}

static TimeSpan? GetRefreshInterval(string[] arguments)
{
    const string intervalPrefix = "--interval=";
    var intervalArgument = arguments.FirstOrDefault(arg =>
        arg.StartsWith(intervalPrefix, StringComparison.OrdinalIgnoreCase));

    if (intervalArgument == null)
    {
        return null;
    }

    var intervalText = intervalArgument[intervalPrefix.Length..];
    return int.TryParse(intervalText, out var seconds) && seconds > 0
        ? TimeSpan.FromSeconds(seconds)
        : null;
}

static void TryClearConsole()
{
    if (Console.IsOutputRedirected)
    {
        return;
    }

    try
    {
        Console.Clear();
    }
    catch (IOException)
    {
    }
}

internal sealed record EnergyRow(decimal CurrentProduction, decimal? InstalledCapacity, string? ErrorMessage)
{
    public static EnergyRow Unavailable(string errorMessage)
    {
        return new EnergyRow(0, null, errorMessage);
    }
}
