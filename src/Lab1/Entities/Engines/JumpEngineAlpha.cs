using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Surroundings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpEngineAlpha : IJumpEngine
{
    private double _fuelUse = 1;

    public FlightResult Jump(ISurrounding distance)
    {
        const int maxAlphaJump = 300;
        const int maxAlphaJumpTime = 50;

        double usedTime = maxAlphaJumpTime * (distance.Distance / maxAlphaJump);
        double usedGravitonMatter = _fuelUse * usedTime;

        if (distance.Distance > maxAlphaJump)
            return new FlightResult.LostShip();

        return new FlightResult.Success(
            usedTime,
            new List<IFuel> { new GravitonMatter(usedGravitonMatter) });
    }
}