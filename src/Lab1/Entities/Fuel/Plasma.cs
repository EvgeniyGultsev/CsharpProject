namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuel;

public class Plasma : IFuel
{
    public Plasma(double amount)
    {
        FuelAmount = amount;
    }

    public double FuelAmount { get; }
}