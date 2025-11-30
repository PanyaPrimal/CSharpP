public static class OperatorHelpers
{
    public static bool BothAreNull<T>(T left, T right) where T : class
    {
        return ReferenceEquals(left, null) && ReferenceEquals(right, null);
    }

    public static bool OneIsNull<T>(T left, T right) where T : class
    {
        return ReferenceEquals(left, null) || ReferenceEquals(right, null);
    }

    public static void ThrowIfAnyNull<T>(T left, T right, string message = "Object cannot be null") where T : class
    {
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            throw new ArgumentNullException(message);
    }
}

public abstract class ComparableEntity<T> where T : IComparable<T>
{
    protected abstract T ComparisonValue { get; }

    protected bool IsEqualByValue(ComparableEntity<T> other)
    {
        if (other == null) return false;
        return ComparisonValue.CompareTo(other.ComparisonValue) == 0;
    }

    protected bool IsLessThan(ComparableEntity<T> other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));
        return ComparisonValue.CompareTo(other.ComparisonValue) < 0;
    }

    protected bool IsGreaterThan(ComparableEntity<T> other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));
        return ComparisonValue.CompareTo(other.ComparisonValue) > 0;
    }
}

public class EmployeeOptimized
{
    private string name = "Співробітник";
    private decimal salary;

    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(Name));
    }

    public decimal Salary
    {
        get => salary;
        set
        {
            if (value < 0)
                throw new ArgumentException("Salary cannot be negative");
            salary = value;
        }
    }

    public EmployeeOptimized(string name, decimal salary)
    {
        Name = name;
        Salary = salary;
    }

    public static EmployeeOptimized operator +(EmployeeOptimized employee, decimal amount)
    {
        return new EmployeeOptimized(employee.Name, employee.Salary + amount);
    }

    public static EmployeeOptimized operator -(EmployeeOptimized employee, decimal amount)
    {
        return new EmployeeOptimized(employee.Name, employee.Salary - amount);
    }

    public static bool operator ==(EmployeeOptimized left, EmployeeOptimized right)
    {
        if (OperatorHelpers.BothAreNull(left, right)) return true;
        if (OperatorHelpers.OneIsNull(left, right)) return false;
        return left.Salary == right.Salary;
    }

    public static bool operator !=(EmployeeOptimized left, EmployeeOptimized right)
    {
        return !(left == right);
    }

    public static bool operator <(EmployeeOptimized left, EmployeeOptimized right)
    {
        OperatorHelpers.ThrowIfAnyNull(left, right, "Employee cannot be null");
        return left.Salary < right.Salary;
    }

    public static bool operator >(EmployeeOptimized left, EmployeeOptimized right)
    {
        OperatorHelpers.ThrowIfAnyNull(left, right, "Employee cannot be null");
        return left.Salary > right.Salary;
    }

    public override bool Equals(object? obj)
    {
        if (obj is EmployeeOptimized other)
        {
            return this == other;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Salary.GetHashCode();
    }

    public override string ToString()
    {
        return $"{Name}: {Salary:N0} грн";
    }
}
