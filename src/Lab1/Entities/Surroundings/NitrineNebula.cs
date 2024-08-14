using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Surroundings;

public class NitrineNebula : ISlowingSurrounding
{
    private readonly IEnumerable<INitrineNebulaObstacle> _obstacles;
    public NitrineNebula(IEnumerable<Whale> sections, float distance)
    {
        _obstacles = sections;
        Distance = distance;
        SlowDown = 2;
    }

    public double Distance { get; }
    public double SlowDown { get; }
    public FlightResult GetResult(ISpaceShip ship)
    {
        DamageResult leftDamage = new DamageResult.BlockedAllDamage();
        if (ship.Emitter is null)
        {
            foreach (Whale whale in _obstacles)
            {
                leftDamage = whale.GiveDamage(ship);
            }
        }

        if (leftDamage is DamageResult.NotBlockedDamage)
        {
            return new FlightResult.DestroyedShip();
        }

        return ship.ImpulseEngine.TryGoThroughDistance(this);
    }
}