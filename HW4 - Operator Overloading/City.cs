public class City
{
    private string name = "Місто";
    private int population;

    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(Name));
    }

    public int Population
    {
        get => population;
        set
        {
            if (value < 0)
                throw new ArgumentException("Population cannot be negative");
            population = (int)value;
        }
    }

    public City(string name, int population)
    {
        Name = name;
        Population = population;
    }

    public static City operator +(City city, int amount)
    {
        return new City(city.Name, city.Population + amount);
    }

    public static City operator -(City city, int amount)
    {
        return new City(city.Name, city.Population - amount);
    }

    public static bool operator ==(City left, City right)
    {
        if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
            return true;
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            return false;
        return left.Population == right.Population;
    }

    public static bool operator !=(City left, City right)
    {
        return !(left == right);
    }

    public static bool operator <(City left, City right)
    {
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            throw new ArgumentNullException("City cannot be null");
        return left.Population < right.Population;
    }

    public static bool operator >(City left, City right)
    {
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            throw new ArgumentNullException("City cannot be null");
        return left.Population > right.Population;
    }

    public override bool Equals(object? obj)
    {
        if (obj is City other)
        {
            return this == other;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Population.GetHashCode();
    }

    public override string ToString()
    {
        return $"{Name}: {Population:N0} жителів";
    }
}