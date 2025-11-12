namespace HW2.T3;

public struct DecimalNumber
{
    public int Value { get; set; }

    public DecimalNumber(int value)
    {
        Value = value;
    }

    public string ToBinary()
    {
        if (Value == 0) return "0";
        if (Value < 0) return "-" + Convert.ToString(-Value, 2);
        return Convert.ToString(Value, 2);
    }

    public string ToOctal()
    {
        if (Value == 0) return "0";
        if (Value < 0) return "-" + Convert.ToString(-Value, 8);
        return Convert.ToString(Value, 8);
    }

    public string ToHex()
    {
        if (Value == 0) return "0";
        if (Value < 0) return "-" + Convert.ToString(-Value, 16).ToUpper();
        return Convert.ToString(Value, 16).ToUpper();
    }
}

