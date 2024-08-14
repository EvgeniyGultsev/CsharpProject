namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiModule;

public interface IWiFiModuleBuilder
{
    public IWiFiModuleBuilder WithVersion(string version);
    public IWiFiModuleBuilder WithBluetooth(bool bluetooth);
    public IWiFiModuleBuilder WithPciEVersion(string version);
    public IWiFiModuleBuilder WithPower(int power);
    public IWiFiModuleBuilder WithName(string name);
    public IDiscreteWiFiModule Build();
}