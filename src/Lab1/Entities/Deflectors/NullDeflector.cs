namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class NullDeflector : IDeflector
{
    public DamageResult GetDamage(double damage)
    {
        return new DamageResult.NotBlockedDamage(damage);
    }
}