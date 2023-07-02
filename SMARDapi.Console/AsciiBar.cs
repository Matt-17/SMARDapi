namespace SMARDapi.Console;

public class AsciiBarGenerator
{
    public string Title { get; set; }
    public int MaxValue { get; set; }

    public static int TitleLength = 20;
    public static int BarLength = 50;
    public static int ValueLength = 10;
    public static char FillCharacter = '#';

    public AsciiBarGenerator(string title, int maxValue)
    {
        Title = title;
        MaxValue = maxValue;
    }

    public string GenerateAsciiBar(decimal value)
    {
        var titleLength = Math.Min(20, Title.Length);
        var paddedTitle = Title.PadRight(20);

        var maxValue = MaxValue;
        var barLength = BarLength - 2;
        var filledLength = (int)Math.Round((value / maxValue) * barLength);

        // clamp
        filledLength = Math.Min(filledLength, barLength);
        filledLength = Math.Max(filledLength, 0);
        
        var emptyLength = barLength - filledLength;

        var bar = "[" + new string(FillCharacter, filledLength) + new string(' ', emptyLength) + "]";

        var valueText = $"{value}/{MaxValue}".PadLeft(10).Substring(0, 10);

        return $"{paddedTitle}{bar}{valueText}";
    }

}