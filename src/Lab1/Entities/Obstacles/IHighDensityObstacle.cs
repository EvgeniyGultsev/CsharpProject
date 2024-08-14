namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public interface IHighDensityObstacle : IObstacle
{
    public double PhotonDamage { get; }
}