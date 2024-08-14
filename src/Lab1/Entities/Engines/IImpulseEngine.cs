using Itmo.ObjectOrientedProgramming.Lab1.Entities.Surroundings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public interface IImpulseEngine
{
    public FlightResult TryGoThroughDistance(ISlowingSurrounding distance);
}