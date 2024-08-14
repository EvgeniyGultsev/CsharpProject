using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Exchange;

public class Exchange : IExchange
{
    private double _plasmaPrice;
    private double _gravitonMatterPrice;

    public Exchange()
    {
        _plasmaPrice = 10;
        _gravitonMatterPrice = 20;
    }

    public Exchange(double plasmaPrice, double gravitonMatterPrice)
    {
        _plasmaPrice = plasmaPrice;
        _gravitonMatterPrice = gravitonMatterPrice;
    }

    public double FuelPrice(IFuel amount)
    {
        switch (amount)
        {
            case Plasma:
                return amount.FuelAmount * _plasmaPrice;
            case GravitonMatter:
                return amount.FuelAmount * _gravitonMatterPrice;
            default:
                throw new ArgumentException("Wrong type of fuel");
        }
    }
}