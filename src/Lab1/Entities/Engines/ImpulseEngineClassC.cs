using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Surroundings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class ImpulseEngineClassC : IImpulseEngine
{
    private readonly int _speed;
    private readonly double _fuelUse;
    public ImpulseEngineClassC()
    {
        _speed = 10;
        _fuelUse = 1;
    }

    public FlightResult TryGoThroughDistance(ISlowingSurrounding distance)
    {
        double discriminant = (4 * _speed) - (4 * distance.SlowDown * distance.Distance);
        if (discriminant >= 0)
        {
            double time1 = (_speed / distance.SlowDown) - (discriminant / (2 * distance.SlowDown));
            double time2 = (_speed / distance.SlowDown) + (discriminant / (2 * distance.SlowDown));

            double usedTime = time1 > 0 ? time1 : time2;

            double usedPlasma = (usedTime * _fuelUse) + 1;
            return new FlightResult.Success(
                usedTime,
                new List<IFuel> { new Plasma(usedPlasma) });
        }
        else
        {
            return new FlightResult.LostShip();
        }
    }
}