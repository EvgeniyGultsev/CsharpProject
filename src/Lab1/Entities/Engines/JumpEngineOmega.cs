using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Surroundings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpEngineOmega : IJumpEngine
{
    private double _fuelUse;
    public JumpEngineOmega()
    {
        _fuelUse = 1;
    }

    public FlightResult Jump(ISurrounding distance)
    {
        const int maxOmegaJump = 600;
        const int maxOmegaJumpTime = 100;

        double usedTime = maxOmegaJumpTime * (distance.Distance / maxOmegaJump);
        double usedGravitonMatter = _fuelUse * usedTime * Math.Log(usedTime);

        if (distance.Distance > maxOmegaJump)
            return new FlightResult.LostShip();

        return new FlightResult.Success(usedTime, new List<IFuel> { new GravitonMatter(usedGravitonMatter) });
    }
}