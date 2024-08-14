using Itmo.ObjectOrientedProgramming.Lab1.Entities.Defenders;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Surroundings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Avgur : ISpaceShip
{
    public Avgur(IDeflector photonDeflector)
    {
        Emitter = null;
        Defender = new Defender(photonDeflector, new HullType3());
        ImpulseEngine = new ImpulseEngineClassE();
        JumpEngine = new JumpEngineAlpha();
    }

    public IDefender Defender { get; }
    public IImpulseEngine ImpulseEngine { get; }
    public IJumpEngine JumpEngine { get; }
    public AntiNitrineEmitter? Emitter { get; }

    public FlightResult Fly(ISurrounding surrounding)
    {
        return surrounding.GetResult(this);
    }

    public DamageResult GetDamage(double damage)
    {
        return Defender.TakeDamage(damage);
    }
}