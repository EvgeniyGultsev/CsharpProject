namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuel;

public class GravitonMatter : IFuel
{
    public GravitonMatter(double amount)
    {
        FuelAmount = amount;
    }

    public double FuelAmount { get; }
}