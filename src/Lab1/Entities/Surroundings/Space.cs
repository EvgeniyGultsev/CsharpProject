using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Surroundings;

public class Space : ISlowingSurrounding
{
    private readonly IEnumerable<ISpaceObstacle> _obstacles;
    public Space(IEnumerable<ISpaceObstacle> sections, int distance)
    {
        _obstacles = sections;
        Distance = distance;
        SlowDown = 0;
    }

    public double Distance { get; }
    public double SlowDown { get; }
    public FlightResult GetResult(ISpaceShip ship)
    {
        DamageResult leftDamage = new DamageResult.BlockedAllDamage();
        foreach (ISpaceObstacle asteroidOrMeteorite in _obstacles)
        {
            leftDamage = asteroidOrMeteorite.GiveDamage(ship);
        }

        if (leftDamage is DamageResult.NotBlockedDamage)
        {
            return new FlightResult.DestroyedShip();
        }

        return ship.ImpulseEngine.TryGoThroughDistance(this);
    }
}