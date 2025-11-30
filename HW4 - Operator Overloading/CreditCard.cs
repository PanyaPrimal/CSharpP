public class CreditCard
{
    private string cardNumber = "0000-0000-0000-0000";
    private string cvc = "000";
    private decimal balance;

    public string CardNumber
    {
        get => cardNumber;
        set => cardNumber = value ?? throw new ArgumentNullException(nameof(CardNumber));
    }

    public string CVC
    {
        get => cvc;
        set => cvc = value ?? throw new ArgumentNullException(nameof(CVC));
    }

    public decimal Balance
    {
        get => balance;
        set => balance = value;
    }

    public CreditCard(string cardNumber, string cvc, decimal balance)
    {
        CardNumber = cardNumber;
        CVC = cvc;
        Balance = balance;
    }

    public static CreditCard operator +(CreditCard card, decimal amount)
    {
        return new CreditCard(card.CardNumber, card.CVC, card.Balance + amount);
    }

    public static CreditCard operator -(CreditCard card, decimal amount)
    {
        return new CreditCard(card.CardNumber, card.CVC, card.Balance - amount);
    }

    public static bool operator ==(CreditCard left, CreditCard right)
    {
        if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
            return true;
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            return false;
        return left.CVC == right.CVC;
    }

    public static bool operator !=(CreditCard left, CreditCard right)
    {
        return !(left == right);
    }

    public static bool operator <(CreditCard left, CreditCard right)
    {
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            throw new ArgumentNullException("CreditCard cannot be null");
        return left.Balance < right.Balance;
    }

    public static bool operator >(CreditCard left, CreditCard right)
    {
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            throw new ArgumentNullException("CreditCard cannot be null");
        return left.Balance > right.Balance;
    }

    public override bool Equals(object? obj)
    {
        if (obj is CreditCard other)
        {
            return this == other;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return CVC.GetHashCode();
    }

    public override string ToString()
    {
        return $"Картка {CardNumber} (CVC: {CVC}): {Balance:N2} грн";
    }
}
