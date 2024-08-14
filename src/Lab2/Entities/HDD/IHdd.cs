namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.HDD;

public interface IHdd : IComponent, IHddBuilderDirector
{
    public int Capacity { get; }
    public int SpindleSpeed { get; }
    public int Power { get; }
}