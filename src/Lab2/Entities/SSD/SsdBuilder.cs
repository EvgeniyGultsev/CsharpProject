using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD;

public class SsdBuilder : ISsdBuilder
{
    private ConnectionVersion? _version;
    private int _capacity;
    private int _speed;
    private int _power;
    private string? _name;
    public ISsdBuilder WithConnectionVersion(ConnectionVersion version)
    {
        _version = version;
        return this;
    }

    public ISsdBuilder WithCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public ISsdBuilder WithSpeed(int speed)
    {
        _speed = speed;
        return this;
    }

    public ISsdBuilder WithPower(int power)
    {
        _power = power;
        return this;
    }

    public ISsdBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ISsd Build()
    {
        if (_capacity <= 0) throw new ArgumentException();
        if (_speed <= 0) throw new ArgumentException();
        if (_power <= 0) throw new ArgumentException();
        return new Ssd(
            _version ?? throw new ArgumentNullException(),
            _capacity,
            _speed,
            _power,
            _name ?? throw new ArgumentNullException());
    }
}