using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerSupply;

public class PowerSupplyBuilder : IPowerSupplyBuilder
{
    private int _power;
    private string? _name;
    public IPowerSupplyBuilder WithPower(int power)
    {
        _power = power;
        return this;
    }

    public IPowerSupplyBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IPowerSupply Build()
    {
        if (_power <= 0) throw new ArgumentException();
        return new PowerSupply(
            _power,
            _name ?? throw new ArgumentNullException());
    }
}