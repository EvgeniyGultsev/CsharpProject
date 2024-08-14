using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Surroundings;

public interface ISurrounding
{
    public double Distance { get; }
    public FlightResult GetResult(ISpaceShip ship);
}