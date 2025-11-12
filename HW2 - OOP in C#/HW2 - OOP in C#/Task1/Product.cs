namespace HW2.T1;

public class Product {
    private string name;
    private Money price;
    private string description;

    public Product(string name, Money price, string description = "") {
        if (string.IsNullOrWhiteSpace(name)) {
            throw new ArgumentException("Product name cannot be empty");
        }

        this.name = name;
        this.price = price ?? throw new ArgumentNullException(nameof(price));
        this.description = description;
    }

    public string Name {
        get => name;
        set {
            if (string.IsNullOrWhiteSpace(value)) {
                throw new ArgumentException("Product name cannot be empty");
            }
            name = value;
        }
    }

    public Money Price {
        get => price;
        set => price = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Description {
        get => description;
        set => description = value ?? "";
    }

    public void IncreasePrice(int hryvnias, int kopiyky) {
        int totalKopiyky = price.Kopiyky + kopiyky;
        int additionalHryvnias = totalKopiyky / 100;
        totalKopiyky %= 100;

        price.Hryvnias += price.Hryvnias + hryvnias + additionalHryvnias;
        price.Kopiyky = totalKopiyky;
    }

    public void DecreasePrice(int hryvnias, int kopiyky) {
        int currentTotalKopiyky = price.Hryvnias * 100 + price.Kopiyky;
        int decreaseTotalKopiyky = hryvnias * 100 + kopiyky;

        if (decreaseTotalKopiyky > currentTotalKopiyky) {
            throw new ArgumentException("Cannot decrease price below zero");
        }

        int newTotalKopiyky = currentTotalKopiyky - decreaseTotalKopiyky;
        price.Hryvnias = newTotalKopiyky / 100;
        price.Kopiyky = newTotalKopiyky % 100;
    }

    public void DisplayInfo() {
        Console.WriteLine($"Product: {name}");
        Console.WriteLine($"Price: {price.DisplayAmount()}");
        if (!string.IsNullOrEmpty(description)) {
            Console.WriteLine($"Description: {description}");
        }
    }

    public override string ToString() {
        return $"{name} - {price.DisplayAmount()}";
    }
}
