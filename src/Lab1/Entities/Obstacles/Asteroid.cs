using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Asteroid : ISpaceObstacle
{
    public Asteroid()
    {
        Damage = 1;
    }

    public double Damage { get; }
    public DamageResult GiveDamage(ISpaceShip ship)
    {
        return ship.Defender.TakeDamage(Damage);
    }
}