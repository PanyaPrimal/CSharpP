using System;

namespace CalculatorLib;

public class ScientificCalculator : BasicCalculator
{
    public new double Divide(double a, double b)
    {
        const double epsilon = 1e-10;

        if (Math.Abs(b) < epsilon && b != 0)
        {
            Console.WriteLine($"Warning: Dividing by very small number ({b}) may result in precision issues");
        }

        double result = base.Divide(a, b);
        Console.WriteLine($"ScientificCalculator: {a} / {b} = {result}");
        return result;
    }

    public double Pow(double baseValue, double exponent) => Math.Pow(baseValue, exponent);

    public double Sqrt(double value) => value >= 0 
        ? Math.Sqrt(value) 
        : throw new ArgumentException("Cannot calculate square root of negative number");

    public double Sin(double angleInRadians) => Math.Sin(angleInRadians);

    public double Cos(double angleInRadians) => Math.Cos(angleInRadians);

    public double Tan(double angleInRadians) => Math.Tan(angleInRadians);

    public double Log(double value) => value > 0 
        ? Math.Log(value) 
        : throw new ArgumentException("Cannot calculate logarithm of non-positive number");

    public double Log10(double value) => value > 0 
        ? Math.Log10(value) 
        : throw new ArgumentException("Cannot calculate logarithm of non-positive number");
}

