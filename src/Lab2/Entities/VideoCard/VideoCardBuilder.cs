using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;

public class VideoCardBuilder : IVideoCardBuilder
{
    private double _length;
    private double _width;
    private string? _version;
    private int _frequency;
    private int _power;
    private string? _name;
    public IVideoCardBuilder WithLength(double length)
    {
        _length = length;
        return this;
    }

    public IVideoCardBuilder WithWidth(double width)
    {
        _width = width;
        return this;
    }

    public IVideoCardBuilder WithPciEVersion(string version)
    {
        _version = version;
        return this;
    }

    public IVideoCardBuilder WithChipFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public IVideoCardBuilder WithNeededPower(int power)
    {
        _power = power;
        return this;
    }

    public IVideoCardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IDiscreteVideoCard Build()
    {
        if (_length <= 0) throw new ArgumentException();
        if (_width <= 0) throw new ArgumentException();
        if (_frequency <= 0) throw new ArgumentException();
        if (_power <= 0) throw new ArgumentException();
        return new DiscreteVideoCard(
            _length,
            _width,
            _version ?? throw new ArgumentNullException(),
            _frequency,
            _power,
            _name ?? throw new ArgumentNullException());
    }
}