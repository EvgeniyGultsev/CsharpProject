namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiModule;

public interface IDiscreteWiFiModule : IComponent, IWiFiModuleBuilderDirector, IWifiModule
{
    public string PciEVersion { get; }
    public int Power { get; }
}