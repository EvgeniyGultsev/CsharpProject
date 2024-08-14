namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerSupply;

public class PowerSupply : IPowerSupply
{
    internal PowerSupply(int power, string name)
    {
        Power = power;
        Name = name;
    }

    public int Power { get; }
    public string Name { get; }

    public void Direct(IPowerSupplyBuilder builder)
    {
        throw new System.NotImplementedException();
    }
}