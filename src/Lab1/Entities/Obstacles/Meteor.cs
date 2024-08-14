using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Meteor : ISpaceObstacle
{
    public Meteor()
    {
        Damage = 2;
    }

    public double Damage { get; }
    public DamageResult GiveDamage(ISpaceShip ship)
    {
        return ship.Defender.TakeDamage(Damage);
    }
}