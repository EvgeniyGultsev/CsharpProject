using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Surroundings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpEngineGamma : IJumpEngine
{
    private double _fuelUse;
    public JumpEngineGamma()
    {
        _fuelUse = 1;
    }

    public FlightResult Jump(ISurrounding distance)
    {
        const int maxGammaJump = 900;
        const int maxGammaJumpTime = 150;

        double usedTime = maxGammaJumpTime * (distance.Distance / maxGammaJump);
        double usedGravitonMatter = _fuelUse * usedTime * usedTime;

        if (distance.Distance > maxGammaJump)
            return new FlightResult.LostShip();

        return new FlightResult.Success(
            usedTime,
            new List<IFuel> { new GravitonMatter(usedGravitonMatter) });
    }
}