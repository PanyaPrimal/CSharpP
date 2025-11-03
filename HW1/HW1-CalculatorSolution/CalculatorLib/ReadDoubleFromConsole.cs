using System.Globalization;

namespace CalculatorLib;

public static class InputHelper
{
    public static double ReadDoubleFromConsole()
    {
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
            throw new FormatException("Input cannot be empty.");

        if (!double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
            throw new FormatException($"\"{input}\" — not a number. Use point as divider(example: 3.14).");

        return result;
    }
}
