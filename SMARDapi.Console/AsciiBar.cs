namespace SMARDapi.CommandLine;

public class AsciiBarGenerator
{
    public string Title { get; set; }
    public decimal MaxValue { get; set; }

    public static int TitleLength = 20;
    public static int BarLength = 50;
    public static int ValueLength = 10;
    public static char FillCharacter = '#';

    public AsciiBarGenerator(string title, decimal maxValue)
    {
        Title = title;
        MaxValue = maxValue;
    }

    public string GenerateAsciiBar(decimal value)
    {
        var paddedTitle = FormatTitle(Title);
        var innerBarLength = Math.Max(0, BarLength - 2);
        var percentage = MaxValue <= 0 ? 0 : value / MaxValue;
        var filledLength = (int)Math.Round(percentage * innerBarLength);

        filledLength = Math.Min(filledLength, innerBarLength);
        filledLength = Math.Max(filledLength, 0);

        var emptyLength = innerBarLength - filledLength;
        var bar = "[" + new string(FillCharacter, filledLength) + new string(' ', emptyLength) + "]";
        var valueText = $"{percentage * 100:F0}%".PadLeft(5);

        return $"{paddedTitle}{bar}{valueText}";
    }

    public void PrintAsciiBar(decimal value)
    {
        Console.WriteLine(GenerateAsciiBar(value));
    }

    private static string FormatTitle(string title)
    {
        var maxTitleLength = Math.Max(0, TitleLength);
        var trimmedTitle = title.Length > maxTitleLength
            ? title[..maxTitleLength]
            : title;

        return trimmedTitle.PadRight(maxTitleLength);
    }
}
