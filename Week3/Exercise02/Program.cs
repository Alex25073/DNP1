
namespace Exercise02;

public static class Program
{
    public static void Main(string[] args)
    {
        Company company = new Company();

        company.AddEmployee(new FullTimeEmployee("Alice", 5000));
        company.AddEmployee(new PartTimeEmployee("Bob", 80, 20));
        company.AddEmployee(new FullTimeEmployee("Charlie", 6000));
        company.AddEmployee(new PartTimeEmployee("Diana", 100, 250));

        Console.WriteLine($"Total monthly salary expense: {company.GetMonthlySalaryTotal()}");
        company.DisplayMostExpensiveEmployee();
    }
}