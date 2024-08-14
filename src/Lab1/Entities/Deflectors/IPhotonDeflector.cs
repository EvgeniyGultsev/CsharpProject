namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public interface IPhotonDeflector : IDeflector
{
    public DamageResult GetPhotonDamage(double damage);
}