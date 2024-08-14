using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Surroundings;

public class HighDensityNebula : ISurrounding
{
    private readonly IEnumerable<IHighDensityObstacle> _obstacles;
    public HighDensityNebula(IEnumerable<Antimatter> sections, int distance)
    {
        _obstacles = sections;
        Distance = distance;
    }

    public double Distance { get; }

    public FlightResult GetResult(ISpaceShip ship)
    {
        DamageResult leftDamage = new DamageResult.BlockedAllDamage();
        foreach (Antimatter antimatter in _obstacles)
        {
            leftDamage = antimatter.GiveDamage(ship);
        }

        if (leftDamage is DamageResult.NotBlockedDamage)
        {
            return new FlightResult.CrewDeath();
        }

        if (ship.JumpEngine is null)
            return new FlightResult.NoEngineForHighDensitynebula();
        return ship.JumpEngine.Jump(this);
    }
}