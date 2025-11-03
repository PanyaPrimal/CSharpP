using CalculatorLib;
using System.Globalization;

namespace CalculatorApp;

public class Program
{
    public static void Main()
    {
        Run();
    }

    public static void Run()
    {
        Console.WriteLine("Welcome to the Calculator App!");
        
        while (true)
        {
            var calculator = SelectCalculator();
            
            if (calculator == null)
            {
                Console.WriteLine("Invalid calculator type selected. Try again.");
                continue;
            }

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Would you like to perform a calculation? Type (y/n)");
                string? response = Console.ReadLine();

                if (response?.ToLower() != "y")
                    break;

                try
                {
                    PerformCalculation(calculator);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }

    private static BasicCalculator? SelectCalculator()
    {
        Console.WriteLine();
        Console.WriteLine("Select calculator type:");
        Console.WriteLine("1. Basic Calculator (+, -, *, /)");
        Console.WriteLine("2. Scientific Calculator (Pow, Sqrt, Sin, Cos, etc.)");
        Console.WriteLine("3. Programmer Calculator (Binary, Hex, Bitwise operations)");
        Console.Write("Enter your choice (1-3): ");
        
        string? choice = Console.ReadLine();
        
        return choice switch
        {
            "1" => new BasicCalculator(),
            "2" => new ScientificCalculator(),
            "3" => new ProgrammerCalculator(),
            _ => null
        };
    }

    private static void PerformCalculation(BasicCalculator calculator)
    {
        string operationPrompt = calculator switch
        {
            ScientificCalculator => "Select operation (+, -, *, /, pow, sqrt, sin, cos, tan, log, log10):",
            ProgrammerCalculator => "Select operation (+, -, *, /, tobinary, tohex, and, or, xor):",
            _ => "Select operation (+, -, *, /):"
        };

        Console.WriteLine("Enter first number:");
        double num1 = CalculatorLib.InputHelper.ReadDoubleFromConsole();

        double result;

        if (calculator is ScientificCalculator sciCalc)
        {
            Console.WriteLine(operationPrompt);
            string? operation = Console.ReadLine()?.ToLower();

            result = operation switch
            {
                "+" => sciCalc.Add(num1, GetSecondNumber()),
                "-" => sciCalc.Subtract(num1, GetSecondNumber()),
                "*" => sciCalc.Multiply(num1, GetSecondNumber()),
                "/" => sciCalc.Divide(num1, GetSecondNumber()),
                "pow" => sciCalc.Pow(num1, GetSecondNumber()),
                "sqrt" => sciCalc.Sqrt(num1),
                "sin" => sciCalc.Sin(num1),
                "cos" => sciCalc.Cos(num1),
                "tan" => sciCalc.Tan(num1),
                "log" => sciCalc.Log(num1),
                "log10" => sciCalc.Log10(num1),
                _ => throw new InvalidOperationException("Invalid operation, choose provided one")
            };
        }
        else if (calculator is ProgrammerCalculator progCalc)
        {
            Console.WriteLine(operationPrompt);
            string? operation = Console.ReadLine()?.ToLower();

            long num1Long = (long)num1;
            
            if (operation == "tobinary")
            {
                string binary = progCalc.ToBinary(num1Long);
                Console.WriteLine($"Binary: {binary}");
                result = num1;
            }
            else if (operation == "tohex")
            {
                string hex = progCalc.ToHex(num1Long);
                Console.WriteLine($"Hex: {hex}");
                result = num1;
            }
            else
            {
                result = operation switch
                {
                    "+" => progCalc.Add(num1, GetSecondNumber()),
                    "-" => progCalc.Subtract(num1, GetSecondNumber()),
                    "*" => progCalc.Multiply(num1, GetSecondNumber()),
                    "/" => progCalc.Divide(num1, GetSecondNumber()),
                    "and" => progCalc.And(num1Long, (long)GetSecondNumber()),
                    "or" => progCalc.Or(num1Long, (long)GetSecondNumber()),
                    "xor" => progCalc.Xor(num1Long, (long)GetSecondNumber()),
                    _ => throw new InvalidOperationException("Invalid operation, choose provided one")
                };
            }
        }
        else
        {
            Console.WriteLine("Enter second number:");
            double num2 = CalculatorLib.InputHelper.ReadDoubleFromConsole();

            Console.WriteLine(operationPrompt);
            string? operation = Console.ReadLine();

            result = operation switch
            {
                "+" => calculator.Add(num1, num2),
                "-" => calculator.Subtract(num1, num2),
                "*" => calculator.Multiply(num1, num2),
                "/" => calculator.Divide(num1, num2),
                _ => throw new InvalidOperationException("Invalid operation, choose provided one")
            };
        }

        Console.WriteLine($"Result: {result}");
        Console.WriteLine();
        Console.WriteLine($"Last result is: {calculator.LastResult}");
        calculator.SetLastResult(result);
    }

    private static double GetSecondNumber()
    {
        Console.WriteLine("Enter second number:");
        return CalculatorLib.InputHelper.ReadDoubleFromConsole();
    }
}
