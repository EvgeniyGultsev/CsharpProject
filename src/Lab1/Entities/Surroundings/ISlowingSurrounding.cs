namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Surroundings;

public interface ISlowingSurrounding : ISurrounding
{
    public double SlowDown { get; }
}