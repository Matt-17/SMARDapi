using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Text;

namespace SMARDapi.Console.Tests;

[TestClass]
public class AsciiBarGeneratorTests
{
    [TestMethod]
    public void GenerateAsciiBar_ValidValue_ReturnsCorrectAsciiBar()
    {
        // Arrange
        var generator = new AsciiBarGenerator("ENERGIEART", 100);
        var value = 40;
        var expectedBar = "ENERGIEART          [" + new string('#', 19) + new string(' ', 29) + "]    40/100";

        // Act
        var result = generator.GenerateAsciiBar(value);
        var diffChars = ShowDiffs(expectedBar, result);

        // Assert
        Assert.IsTrue(string.Equals(expectedBar, result), $"Differences: {diffChars}");
    }

    [TestMethod]
    public void GenerateAsciiBar_ZeroValue_ReturnsEmptyBar()
    {
        // Arrange
        var generator = new AsciiBarGenerator("ENERGIEART", 100);
        var value = 0;
        var expectedBar = "ENERGIEART          [" + new string(' ', 48) + "]     0/100";

        // Act
        var result = generator.GenerateAsciiBar(value);
        var diffChars = ShowDiffs(expectedBar, result);

        // Assert
        Assert.IsTrue(string.Equals(expectedBar, result), $"Differences: {diffChars}");
    }

    [TestMethod]
    public void GenerateAsciiBar_MaxValue_ReturnsFullBar()
    {
        // Arrange
        var generator = new AsciiBarGenerator("ENERGIEART", 100);
        var value = 100;
        var expectedBar = "ENERGIEART          [" + new string('#', 48) + "]   100/100";

        // Act
        var result = generator.GenerateAsciiBar(value);
        var diffChars = ShowDiffs(expectedBar, result);

        // Assert
        Assert.IsTrue(string.Equals(expectedBar, result), $"Differences: {diffChars}");
    }
    [TestMethod]
    public void GenerateAsciiBar_ValueGreaterThanMaxValue_ReturnsFullBar()
    {
        // Arrange
        var generator = new AsciiBarGenerator("ENERGIEART", 100);
        var value = 150;
        var expectedBar = "ENERGIEART          [" + new string('#', 48) + "]   150/100";

        // Act
        var result = generator.GenerateAsciiBar(value);
        var diffChars = ShowDiffs(expectedBar, result);

        // Assert
        Assert.IsTrue(string.Equals(expectedBar, result), $"Differences: {diffChars}");
    }


    public string ShowDiffs(string? a, string? b)
    {
        if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
            return new string('*', Math.Max(a?.Length ?? 0, b?.Length ?? 0) + 1);

        var diffChars = new StringBuilder();

        for (int i = 0; i < Math.Min(a.Length, b.Length); i++)
        {
            if (a[i] == b[i])
            {
                diffChars.Append(a[i]);
            }
            else
            {
                diffChars.Append("*");
            }
        }

        var lengthDiff = Math.Abs(a.Length - b.Length);
        if (lengthDiff > 0)
        {
            diffChars.Append(new string('^', lengthDiff));
        }

        return diffChars.ToString();
    }
}