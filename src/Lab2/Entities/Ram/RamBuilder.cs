using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Ram;

public class RamBuilder : IRamBuilder
{
    private int _storage;
    private IEnumerable<int>? _frequency;
    private IEnumerable<int>? _voltage;
    private IEnumerable<XmpOrDocp>? _profiles;
    private RamFormFactor? _ramFormFactor;
    private DdrType? _ddrType;
    private int _power;
    private string? _name;
    public IRamBuilder WithStorage(int storage)
    {
        _storage = storage;
        return this;
    }

    public IRamBuilder WithAcceptedFrequency(IEnumerable<int> frequency)
    {
        _frequency = frequency;
        return this;
    }

    public IRamBuilder WithAcceptedVoltage(IEnumerable<int> voltage)
    {
        _voltage = voltage;
        return this;
    }

    public IRamBuilder WithProfiles(IEnumerable<XmpOrDocp> profiles)
    {
        _profiles = profiles;
        return this;
    }

    public IRamBuilder WithRamFormFactor(RamFormFactor ramFormFactor)
    {
        _ramFormFactor = ramFormFactor;
        return this;
    }

    public IRamBuilder WithDdrType(DdrType ddrType)
    {
        _ddrType = ddrType;
        return this;
    }

    public IRamBuilder WithPower(int power)
    {
        _power = power;
        return this;
    }

    public IRamBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IRam Build()
    {
        if (_storage <= 0) throw new ArgumentException();
        if (_power <= 0) throw new ArgumentException();
        return new Ram(
            _storage,
            (_frequency ?? throw new ArgumentNullException()).ToList(),
            (_voltage ?? throw new ArgumentNullException()).ToList(),
            (_profiles ?? throw new ArgumentNullException()).ToList(),
            _ramFormFactor ?? throw new ArgumentNullException(),
            _ddrType ?? throw new ArgumentNullException(),
            _power,
            _name ?? throw new ArgumentNullException());
    }
}