using Itmo.ObjectOrientedProgramming.Lab1.Entities.Defenders;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Surroundings;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Shuttle : ISpaceShip
{
    public Shuttle()
    {
        Defender = new Defender(new NullDeflector(), new HullType1());
        ImpulseEngine = new ImpulseEngineClassC();
        JumpEngine = null;
        Emitter = null;
    }

    public IDefender Defender { get; }
    public IImpulseEngine ImpulseEngine { get; }
    public IJumpEngine? JumpEngine { get; }
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