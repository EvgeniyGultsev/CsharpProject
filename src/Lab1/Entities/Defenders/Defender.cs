using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Defenders;

public class Defender : IDefender
{
    public Defender(IDeflector deflector, IHull hull)
    {
        Deflector = deflector;
        Hull = hull;
    }

    public IHull Hull { get; }
    public IDeflector Deflector { get; }

    public DamageResult TakeDamage(double damage)
    {
        DamageResult temporaryResult = Deflector.GetDamage(damage);
        if (temporaryResult is DamageResult.NotBlockedDamage notBlockedDamage)
        {
            return Hull.GetDamage(notBlockedDamage.Damage);
        }
        else
        {
            return temporaryResult;
        }
    }
}