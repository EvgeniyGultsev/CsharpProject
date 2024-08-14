namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerSupply;

public interface IPowerSupplyBuilder
{
    public IPowerSupplyBuilder WithPower(int power);
    public IPowerSupplyBuilder WithName(string name);
    public IPowerSupply Build();
}