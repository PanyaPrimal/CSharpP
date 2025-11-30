public class Employee
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

    public Employee(string name, decimal salary)
    {
        Name = name;
        Salary = salary;
    }
    public static Employee operator +(Employee employee, decimal amount)
    {
        return new Employee(employee.Name, employee.Salary + amount);
    }

    public static Employee operator -(Employee employee, decimal amount)
    {
        return new Employee(employee.Name, employee.Salary - amount);
    }

    public static bool operator ==(Employee left, Employee right)
    {
        if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
            return true;
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            return false;
        return left.Salary == right.Salary;
    }

    public static bool operator !=(Employee left, Employee right)
    {
        return !(left == right);
    }

    public static bool operator <(Employee left, Employee right)
    {
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            throw new ArgumentNullException("Employee cannot be null");
        return left.Salary < right.Salary;
    }

    public static bool operator >(Employee left, Employee right)
    {
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            throw new ArgumentNullException("Employee cannot be null");
        return left.Salary > right.Salary;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Employee other)
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
