using System;

namespace Exercise02;

public class Company
{

    List<Employee> employees = new List<Employee>();

    public double GetMonthlySalaryTotal()
    {
        double total = 0;
        foreach (var emp in employees)
        {
            total += emp.GetMonthlySalary();
        }
        return total;
    }

    public void AddEmployee(Employee emp)
    {
        if (emp == null)
        {
            throw new ArgumentNullException(nameof(emp), "Employee cannot be null");
        }
        employees.Add(emp);
    }

    public void DisplayMostExpensiveEmployee()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees in the company.");
            return;
        }
        var mostExpensive = employees.OrderByDescending(e => e.GetMonthlySalary()).First();
        Console.WriteLine($"Most expensive employee: {mostExpensive.Name} with a monthly salary of {mostExpensive.GetMonthlySalary()}");
    }

}
