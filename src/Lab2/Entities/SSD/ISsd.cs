namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD;

public interface ISsd : IComponent, ISsdBuilderDirector
{
    ConnectionVersion ConnectionVersion { get; }
    int Capacity { get; }
    int Speed { get; }
    int Power { get; }
}