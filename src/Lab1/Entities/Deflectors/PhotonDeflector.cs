namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class PhotonDeflector : IPhotonDeflector
{
    private double _photonDeflectorHealthPoints;
    private IDeflector _deflector;
    public PhotonDeflector(IDeflector deflector)
    {
        _deflector = deflector;
        _photonDeflectorHealthPoints = 3;
    }

    public DamageResult GetDamage(double damage)
    {
        return _deflector.GetDamage(damage);
    }

    public DamageResult GetPhotonDamage(double damage)
    {
        if (damage >= _photonDeflectorHealthPoints)
        {
            _photonDeflectorHealthPoints = 0;
            return _deflector.GetDamage(damage);
        }
        else
        {
            _photonDeflectorHealthPoints -= damage;
            return new DamageResult.BlockedAllDamage();
        }
    }
}