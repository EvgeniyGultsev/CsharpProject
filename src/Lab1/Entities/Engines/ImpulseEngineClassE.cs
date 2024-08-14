using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Surroundings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class ImpulseEngineClassE : IImpulseEngine
{
    private double _fuelUse;
    public ImpulseEngineClassE()
    {
        _fuelUse = 3;
    }

    public FlightResult TryGoThroughDistance(ISlowingSurrounding distance)
    {
        double usedTime = Math.Log(distance.Distance) * distance.SlowDown;
        double usedPlasma = (_fuelUse * usedTime) + 1;

        return new FlightResult.Success(
            usedTime,
            new List<IFuel> { new Plasma(usedPlasma) });
    }
}