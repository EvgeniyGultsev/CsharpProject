using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MatherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Ram;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;

public class MotherBoard : IMotherBoard
{
    public MotherBoard(string socket, int pciELines, int sataPorts, Chipset chipset, DdrType ddrType, int ramNumber, FormFactor formFactor, IBios bios, string name, IIntegratedWifiModule? wifiModule)
    {
        Socket = socket;
        PciELines = pciELines;
        SataPorts = sataPorts;
        Chipset = chipset;
        DdrType = ddrType;
        RamNumber = ramNumber;
        FormFactor = formFactor;
        Bios = bios;
        Name = name;
        WifiModule = wifiModule;
    }

    public string Socket { get; }
    public int PciELines { get; }
    public int SataPorts { get; }
    public Chipset Chipset { get; }
    public DdrType DdrType { get; }
    public int RamNumber { get; }
    public FormFactor FormFactor { get; }
    public IBios Bios { get; }
    public IIntegratedWifiModule? WifiModule { get; }
    public string Name { get; }
    public void Direct(IMotherBoardBuilder builder)
    {
        builder.WithName(Name);
        builder.WithBios(Bios);
        builder.WithDdrType(DdrType);
        builder.WithChipset(Chipset);
        builder.WithSocket(Socket);
        builder.WithFormFactor(FormFactor);
        builder.WithRamNumber(RamNumber);
        builder.WithSataPorts(SataPorts);
        builder.WithPciELines(PciELines);
        builder.WithIntegratedWifiModule(WifiModule);
    }
}