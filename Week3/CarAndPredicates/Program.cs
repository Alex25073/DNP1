using System;
using System.Collections.Generic;
using System.Linq;

namespace CarAndPredicates;

public static class Program
{
    public static void Main()
    {
        var cars = SeedCars();

        Print("ALL CARS", cars);

        Print("Color == Blue", CarFilters.ByColor(cars, "Blue"));
        Print("Color == Red OR Black", CarFilters.ByEitherColor(cars, "Red", "Black"));
        Print("HP > 200", CarFilters.ByHorsePowerGreaterThan(cars, 200));
        Print("HP between 120 and 180", CarFilters.ByHorsePowerBetween(cars, 120, 180));
        Print("Fuel < 5.5 L/100km", CarFilters.ByFuelEconomyLowerThan(cars, 5.5));
        Print("Doors == 5", CarFilters.ByDoors(cars, 5));

        Print("Custom: Blue AND HP>=150 AND Automatic",
            CarFilters.WhereAll(cars,
                c => c.Color.Equals("Blue", StringComparison.OrdinalIgnoreCase),
                c => c.HorsePower >= 150,
                c => !c.IsManualShift));

        Print("Custom: (Fuel<5.0 OR HP>300)",
            CarFilters.WhereAny(cars,
                c => c.FuelEconomyLPer100Km < 5.0,
                c => c.HorsePower > 300));
    }

    private static void Print(string title, IEnumerable<Car> items)
    {
        Console.WriteLine($"\n {title} ");
        foreach (var c in items) Console.WriteLine(c);
    }

    private static List<Car> SeedCars()
        => new()
        {
            new() { Make="VW",    Model="Golf",  Year=2020, Color="Blue",  HorsePower=130, FuelEconomyLPer100Km=5.2, IsManualShift=true,  Doors=5 },
            new() { Make="BMW",   Model="330i",  Year=2019, Color="Black", HorsePower=255, FuelEconomyLPer100Km=6.8, IsManualShift=false, Doors=4 },
            new() { Make="Toyota",Model="Yaris", Year=2022, Color="Red",   HorsePower=110, FuelEconomyLPer100Km=4.8, IsManualShift=true,  Doors=5 },
            new() { Make="Audi",  Model="A4",    Year=2018, Color="White", HorsePower=190, FuelEconomyLPer100Km=6.1, IsManualShift=false, Doors=4 },
            new() { Make="Ford",  Model="Focus", Year=2021, Color="Blue",  HorsePower=155, FuelEconomyLPer100Km=5.6, IsManualShift=true,  Doors=5 },
            new() { Make="Volvo", Model="XC40",  Year=2023, Color="Grey",  HorsePower=197, FuelEconomyLPer100Km=6.0, IsManualShift=false, Doors=5 },
            new() { Make="Honda", Model="Civic", Year=2017, Color="Red",   HorsePower=182, FuelEconomyLPer100Km=5.0, IsManualShift=false, Doors=4 },
            new() { Make="Mazda", Model="3",     Year=2024, Color="Blue",  HorsePower=186, FuelEconomyLPer100Km=5.4, IsManualShift=false, Doors=5 },
        };
}
