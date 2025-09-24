using System;

namespace CarAndPredicates;

public class Car
{
    public string? Make { get; init; }
    public string? Model { get; init; }
    public string? Color { get; init; }                 
    public int HorsePower { get; init; }              
    public double FuelEconomyLPer100Km { get; init; }  
    public bool IsManualShift { get; init; }
    public int Doors { get; init; }                    
    public int Year { get; init; }

    public override string ToString()
        => $"{Year} {Make} {Model} | Color: {Color}, HP: {HorsePower}, " +
           $"Fuel: {FuelEconomyLPer100Km:0.0} L/100km, Manual: {IsManualShift}, Doors: {Doors}";
}