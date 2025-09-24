using System;

namespace Exercise02;

public class PartTimeEmployee : Employee
{
    public string Name { get; set; }
    int hoursPerMonth;
    double hourlyWage;

    public PartTimeEmployee(string name, int hoursPerMonth, double hourlyWage)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Name cannot be null or empty", nameof(name));
        }

        if (hoursPerMonth < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(hoursPerMonth), "Hours per month cannot be negative");
        }

        if (hourlyWage < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(hourlyWage), "Hourly wage cannot be negative");
        }

        Name = name;
        this.hoursPerMonth = hoursPerMonth;
        this.hourlyWage = hourlyWage;
    }

    public double GetMonthlySalary()
    {
        return hoursPerMonth * hourlyWage;
    }

}
