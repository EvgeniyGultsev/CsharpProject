using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Exchange;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class ChooseEffectiveTimeShip : IChooseEffectiveShip
{
    public ISpaceShip? FindTheBestShipForTheWay(Way way, IEnumerable<ISpaceShip> ships, IExchange exchange)
    {
        var successfulShips = new Dictionary<double, ISpaceShip>();
        foreach (ISpaceShip ship in ships)
        {
            if (way.TryToFly(ship) is FlightResult.Success success)
            {
                successfulShips.Add(success.UsedTime, ship);
            }
        }

        return successfulShips.Any() ? successfulShips.First().Value : null;
    }
}