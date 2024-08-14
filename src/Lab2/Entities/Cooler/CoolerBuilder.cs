using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Cooler;

public class CoolerBuilder : ICoolerBuilder
{
    private double _height;
    private IEnumerable<string>? _sockets;
    private int _tdp;
    private string? _name;

    public ICoolerBuilder WithHeight(double height)
    {
        _height = height;
        return this;
    }

    public ICoolerBuilder WithSockets(IEnumerable<string> sokets)
    {
        _sockets = new List<string>(sokets);
        return this;
    }

    public ICoolerBuilder WithTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public ICoolerBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ICooler Build()
    {
        if (_height <= 0) throw new ArgumentException();
        if (_tdp <= 0) throw new ArgumentException();
        if (_sockets is null) throw new ArgumentNullException();
        return new Cooler(
            _height,
            _sockets,
            _tdp,
            _name ?? throw new ArgumentNullException());
    }
}