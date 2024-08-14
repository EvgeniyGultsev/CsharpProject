using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Antimatter : IHighDensityObstacle
{
    public Antimatter()
    {
        PhotonDamage = 1;
    }

    public double PhotonDamage { get; }
    public DamageResult GiveDamage(ISpaceShip ship)
    {
        if (ship.Defender.Deflector is PhotonDeflector photonDeflector)
            return photonDeflector.GetPhotonDamage(PhotonDamage);
        return new DamageResult.NotBlockedDamage(1);
    }
}