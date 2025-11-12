namespace HW2.T1;

public class Money {
    private int hryvnias;
    private int kopiyky;
    private string currency;

    private void checkHryvnias (int hryvnias)
    {
        if (hryvnias < 0) {
            throw new ArgumentException("Hryvnias cannot be negative");
        }
    }

    private void checkKopiyky (int kopiyky)
    {
        if (kopiyky < 0 || kopiyky > 99) {
            throw new ArgumentException("Kopiyky must be between 0 and 99");
        }
    }

    public Money(int hryvnias, int kopiyky, string currency = "грн") {
        this.checkHryvnias(hryvnias);
        this.checkKopiyky(kopiyky);
        this.hryvnias = hryvnias;
        this.kopiyky = kopiyky;
        this.currency = currency;
    }

    public int Hryvnias {
        get => hryvnias;
        set {
            checkHryvnias(value);
            hryvnias = value;
        }
    }

    public int Kopiyky {
        get => kopiyky;
        set {
            checkKopiyky(value);
            kopiyky = value;
        }
    }

    public string Currency {
        get => currency;
        set => currency = value ?? "грн";
    }

    public string DisplayAmount() {
        return $"{hryvnias}.{kopiyky:D2} {currency}";
    }

    public void SetAmount(int hryvnias, int kopiyky) {
        checkHryvnias(hryvnias);
        checkKopiyky(kopiyky);
        this.hryvnias = hryvnias;
        this.kopiyky = kopiyky;
    }

    public override bool Equals(object? obj) {
        if (obj is Money other) {
            return hryvnias == other.hryvnias &&
                   kopiyky == other.kopiyky &&
                   currency == other.currency;
        }
        return false;
    }

    public override int GetHashCode() {
        return HashCode.Combine(hryvnias, kopiyky, currency);
    }
}