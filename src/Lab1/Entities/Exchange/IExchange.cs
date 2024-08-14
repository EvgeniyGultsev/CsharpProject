using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Exchange;

public interface IExchange
{
    public double FuelPrice(IFuel amount);
}