using System;

namespace CarAndPredicates;

public static class CarFilters
{
    public static IEnumerable<Car> ByColor(IEnumerable<Car> cars, string color)
        => cars.Where(c => c.Color.Equals(color, StringComparison.OrdinalIgnoreCase));

    public static IEnumerable<Car> ByEitherColor(IEnumerable<Car> cars, string color1, string color2)
        => cars.Where(c =>
            c.Color.Equals(color1, StringComparison.OrdinalIgnoreCase) ||
            c.Color.Equals(color2, StringComparison.OrdinalIgnoreCase));

    public static IEnumerable<Car> ByHorsePowerGreaterThan(IEnumerable<Car> cars, int minHp)
        => cars.Where(c => c.HorsePower > minHp);

    public static IEnumerable<Car> ByHorsePowerBetween(IEnumerable<Car> cars, int minHp, int maxHp)
        => cars.Where(c => c.HorsePower >= minHp && c.HorsePower <= maxHp);

    public static IEnumerable<Car> ByFuelEconomyLowerThan(IEnumerable<Car> cars, double maxLPer100Km)
        => cars.Where(c => c.FuelEconomyLPer100Km < maxLPer100Km);

    public static IEnumerable<Car> ByDoors(IEnumerable<Car> cars, int doors)
        => cars.Where(c => c.Doors == doors);

    public static IEnumerable<Car> WhereAll(IEnumerable<Car> cars, params Func<Car, bool>[] conditions)
        => cars.Where(c => conditions.All(cond => cond(c)));

    public static IEnumerable<Car> WhereAny(IEnumerable<Car> cars, params Func<Car, bool>[] conditions)
        => cars.Where(c => conditions.Any(cond => cond(c)));
}
