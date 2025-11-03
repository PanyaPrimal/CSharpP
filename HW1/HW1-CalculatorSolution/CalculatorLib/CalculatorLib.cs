namespace CalculatorLib;

public class BasicCalculator
{
    private double _lastResult;

    public double LastResult
    {
        get => _lastResult;
        private set => _lastResult = value;
    }

    public double Add(double a, double b) => a + b;
    public double Subtract(double a, double b) => a - b;
    public double Multiply(double a, double b) => a * b;
    public double Divide(double a, double b) =>
        b != 0 ? a / b : throw new DivideByZeroException("Cannot divide by zero");

    public void SetLastResult(double result) => LastResult = result;

}
