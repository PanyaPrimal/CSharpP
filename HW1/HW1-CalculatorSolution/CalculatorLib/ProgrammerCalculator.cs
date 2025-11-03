using System;

namespace CalculatorLib;

public class ProgrammerCalculator : BasicCalculator
{
    public string ToBinary(long value) => Convert.ToString(value, 2);

    public string ToHex(long value) => Convert.ToString(value, 16).ToUpperInvariant();

    public string ToOctal(long value) => Convert.ToString(value, 8);

    public long FromBinary(string binaryString)
    {
        if (string.IsNullOrWhiteSpace(binaryString))
            throw new ArgumentException("Binary string cannot be empty");
        
        return Convert.ToInt64(binaryString, 2);
    }

    public long FromHex(string hexString)
    {
        if (string.IsNullOrWhiteSpace(hexString))
            throw new ArgumentException("Hex string cannot be empty");
        
        return Convert.ToInt64(hexString, 16);
    }

    public long And(long a, long b) => a & b;

    public long Or(long a, long b) => a | b;

    public long Xor(long a, long b) => a ^ b;

    public long Not(long value) => ~value;

    public long LeftShift(long value, int shift) => value << shift;

    public long RightShift(long value, int shift) => value >> shift;
}

