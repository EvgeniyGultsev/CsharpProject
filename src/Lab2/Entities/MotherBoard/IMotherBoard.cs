using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MatherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Ram;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;

public interface IMotherBoard : IComponent, IMotherBoardBuilderDirector
{
    public string Socket { get; }
    public int PciELines { get; }
    public int SataPorts { get; }
    public Chipset Chipset { get; }
    public DdrType DdrType { get; }
    public int RamNumber { get; }
    public FormFactor FormFactor { get; }
    public IBios Bios { get; }
    public IIntegratedWifiModule? WifiModule { get; }
}