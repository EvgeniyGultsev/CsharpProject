using Itmo.ObjectOrientedProgramming.Lab1.Entities.Defenders;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Surroundings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Meredian : ISpaceShip
{
    public Meredian(IDeflector photonDeflector)
    {
        ImpulseEngine = new ImpulseEngineClassE();
        JumpEngine = null;
        Defender = new Defender(photonDeflector, new HullType2());
        Emitter = new AntiNitrineEmitter();
    }

    public IDefender Defender { get; }
    public IImpulseEngine ImpulseEngine { get; }
    public IJumpEngine? JumpEngine { get; }
    public AntiNitrineEmitter Emitter { get; }
    public FlightResult Fly(ISurrounding surrounding)
    {
        return surrounding.GetResult(this);
    }

    public DamageResult GetDamage(double damage)
    {
        return Defender.TakeDamage(damage);
    }
}