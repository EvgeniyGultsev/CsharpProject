namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerSupply;

public interface IPowerSupply : IComponent, IPowerSupplyDirector
{
    public int Power { get; }
}