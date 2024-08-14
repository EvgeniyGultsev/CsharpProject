using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Exchange;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public interface IChooseEffectiveShip
{
    public ISpaceShip? FindTheBestShipForTheWay(Way way, IEnumerable<ISpaceShip> ships, IExchange exchange);
}