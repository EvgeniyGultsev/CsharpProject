using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Surroundings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Way
{
    private readonly IEnumerable<ISurrounding> _parts;

    public Way(IEnumerable<ISurrounding> parts)
    {
        _parts = parts;
    }

    public FlightResult TryToFly(ISpaceShip ship)
    {
        var temporaryResult = new FlightResult.Success(0, new List<IFuel>());
        foreach (ISurrounding segment in _parts)
        {
            FlightResult temporaryFlightResult = ship.Fly(segment);
            if (temporaryFlightResult is FlightResult.Success goodResult)
            {
                temporaryResult = new FlightResult.Success(
                    goodResult.UsedTime + temporaryResult.UsedTime,
                    new List<IFuel>(temporaryResult.UsedFuel.Concat(goodResult.UsedFuel)));
            }
            else
            {
                return temporaryFlightResult;
            }
        }

        return temporaryResult;
    }
}