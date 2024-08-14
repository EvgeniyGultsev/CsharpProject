using Itmo.ObjectOrientedProgramming.Lab1.Entities.Surroundings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public interface IJumpEngine
{
    public FlightResult Jump(ISurrounding distance);
}