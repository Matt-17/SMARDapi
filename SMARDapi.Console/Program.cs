using SMARDapi.Console;
using SMARDapi.Models;
using SMARDapi.Models.FilterTypes;


using var client = new SmardClient();

// dictionary with all EnergieartTypes


try
{
    // Get all Energiearten

    foreach (var energieart in EnergieartTypes.Values)
    {
        // get the name of the Energieart
        var energieartName = energieart.DisplayName;

        // Fetch the table data for the Energieart
        var tableResult = await client.GetEnergieartTableData(energieart);

        // Calculate the total value for the Energieart
        var totalValue = tableResult.Series.Last(x => x.Value != null);

        // Generate ASCII bar
        var asciiBarGenerator = new AsciiBarGenerator(energieartName, 1000); // Adjust the max value as needed
        var asciiBar = asciiBarGenerator.GenerateAsciiBar(totalValue.Value ?? 0);

        // Display Energieart with ASCII bar
        Console.WriteLine($"{asciiBar}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

Console.ReadLine();