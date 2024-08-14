using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;

public class CpuBuilder : ICpuBuilder
{
    private int _coreFrequency;
    private int _coreNumber;
    private string? _socket;
    private IIntegratedVideoCard? _videoCore;
    private IEnumerable<int>? _acceptableRamFrequency;
    private int _tdp;
    private int _power;
    private string? _name;
    public ICpuBuilder WithCoreFrequency(int coreFrequency)
    {
        _coreFrequency = coreFrequency;
        return this;
    }

    public ICpuBuilder WithCoreNumber(int coreNumber)
    {
        _coreNumber = coreNumber;
        return this;
    }

    public ICpuBuilder WithSocket(string socket)
    {
        _socket = socket;
        return this;
    }

    public ICpuBuilder WithVideoCore(IIntegratedVideoCard? core)
    {
        _videoCore = core;
        return this;
    }

    public ICpuBuilder WithAcceptableRamFrequency(IEnumerable<int> acceptableRamFrequency)
    {
        _acceptableRamFrequency = new List<int>(acceptableRamFrequency);
        return this;
    }

    public ICpuBuilder WithTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public ICpuBuilder WithPower(int power)
    {
        _power = power;
        return this;
    }

    public ICpuBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ICpu Build()
    {
        if (_acceptableRamFrequency is null) throw new ArgumentNullException();
        if (_coreFrequency <= 0) throw new ArgumentException();
        if (_coreNumber <= 0) throw new ArgumentException();
        if (_tdp <= 0) throw new ArgumentException();
        if (_power <= 0) throw new ArgumentException();
        return new Cpu(
            _coreFrequency,
            _coreNumber,
            _socket ?? throw new ArgumentNullException(),
            _videoCore,
            _acceptableRamFrequency.ToList(),
            _tdp,
            _power,
            _name ?? throw new ArgumentNullException());
    }
}