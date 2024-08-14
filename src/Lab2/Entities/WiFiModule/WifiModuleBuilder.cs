using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiModule;

public class WifiModuleBuilder : IWiFiModuleBuilder
{
    private string? _version;
    private bool _bluetooth;
    private string? _pciEVersion;
    private int _power;
    private string? _name;
    public IWiFiModuleBuilder WithVersion(string version)
    {
        _version = version;
        return this;
    }

    public IWiFiModuleBuilder WithBluetooth(bool bluetooth)
    {
        _bluetooth = bluetooth;
        return this;
    }

    public IWiFiModuleBuilder WithPciEVersion(string version)
    {
        _pciEVersion = version;
        return this;
    }

    public IWiFiModuleBuilder WithPower(int power)
    {
        _power = power;
        return this;
    }

    public IWiFiModuleBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IDiscreteWiFiModule Build()
    {
        if (_power <= 0) throw new ArgumentException();
        return new WifiModule(
            _version ?? throw new ArgumentNullException(),
            _bluetooth,
            _pciEVersion ?? throw new ArgumentNullException(),
            _power,
            _name ?? throw new ArgumentNullException());
    }
}