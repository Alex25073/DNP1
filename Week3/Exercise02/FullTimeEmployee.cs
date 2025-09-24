using System;

namespace Exercise02;

public class FullTimeEmployee : Employee
{
    public string Name { get; set; }
    double monthlySalary;

    public FullTimeEmployee(string name, double monthlySalary)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Name cannot be null or empty", nameof(name));
        }

        if (monthlySalary < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(monthlySalary), "Monthly salary cannot be negative");
        }

        Name = name;
        this.monthlySalary = monthlySalary;
    }

    public double GetMonthlySalary()
    {
        return monthlySalary;
    }

}
