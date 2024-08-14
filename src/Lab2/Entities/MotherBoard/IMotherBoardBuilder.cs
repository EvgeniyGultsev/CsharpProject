using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MatherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Ram;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;

public interface IMotherBoardBuilder
{
    public IMotherBoardBuilder WithIntegratedWifiModule(IIntegratedWifiModule? wifiModule);
    public IMotherBoardBuilder WithSocket(string socket);
    public IMotherBoardBuilder WithPciELines(int lines);
    public IMotherBoardBuilder WithSataPorts(int ports);
    public IMotherBoardBuilder WithChipset(Chipset chipset);
    public IMotherBoardBuilder WithDdrType(DdrType ddrType);
    public IMotherBoardBuilder WithRamNumber(int ramNumber);
    public IMotherBoardBuilder WithFormFactor(FormFactor formFactor);
    public IMotherBoardBuilder WithBios(IBios bios);
    public IMotherBoardBuilder WithName(string name);
    public IMotherBoard Build();
}