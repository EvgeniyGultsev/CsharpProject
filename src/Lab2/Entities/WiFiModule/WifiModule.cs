namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiModule;

public class WifiModule : IDiscreteWiFiModule
{
    internal WifiModule(string version, bool bluetooth, string pciEVersion, int power, string name)
    {
        Version = version;
        Bluetooth = bluetooth;
        PciEVersion = pciEVersion;
        Power = power;
        Name = name;
    }

    public string Version { get; }
    public bool Bluetooth { get; }
    public string PciEVersion { get; }
    public int Power { get; }
    public string Name { get; }

    public void Direct(IWiFiModuleBuilder builder)
    {
        builder.WithPower(Power);
        builder.WithPciEVersion(PciEVersion);
        builder.WithName(Name);
        builder.WithBluetooth(Bluetooth);
        builder.WithVersion(Version);
    }
}