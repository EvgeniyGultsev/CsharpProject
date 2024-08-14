using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.HDD;

public class HddBuilder : IHddBuilder
{
    private string? _name;
    private int _capacity;
    private int _spindleSpeed;
    private int _power;

    public IHddBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IHddBuilder WithCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public IHddBuilder WithSpindleSpeed(int speed)
    {
        _spindleSpeed = speed;
        return this;
    }

    public IHddBuilder WithPower(int power)
    {
        _power = power;
        return this;
    }

    public IHdd Build()
    {
        if (_capacity <= 0) throw new ArgumentException();
        if (_spindleSpeed <= 0) throw new ArgumentException();
        if (_power <= 0) throw new ArgumentException();
        return new Hdd(
            _name ?? throw new ArgumentNullException(),
            _capacity,
            _spindleSpeed,
            _power);
    }
}