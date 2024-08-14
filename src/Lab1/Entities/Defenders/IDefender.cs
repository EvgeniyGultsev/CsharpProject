using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Defenders;

public interface IDefender
{
    public IHull Hull { get; }
    public IDeflector Deflector { get; }
    public DamageResult TakeDamage(double damage);
}