using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cooler;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiModule;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

public interface IComputerBuilder
{
    public IComputerBuilder WithMotherBoard(IMotherBoard? motherBoard);
    public IComputerBuilder WithCpu(ICpu? cpu);
    public IComputerBuilder WithCooler(ICooler? cooler);
    public IComputerBuilder WithRam(IEnumerable<IRam> ram);
    public IComputerBuilder WithVideoCard(IDiscreteVideoCard? videoCard);
    public IComputerBuilder WithSsd(IEnumerable<ISsd> ssd);
    public IComputerBuilder WithHdd(IEnumerable<IHdd> hdd);
    public IComputerBuilder WithComputerCase(IComputerCase? computerCase);
    public IComputerBuilder WithPowerSupply(IPowerSupply? powerSupply);
    public IComputerBuilder WithWifi(IDiscreteWiFiModule? wiFiModule);
    public ConfiguratorResult Build();
}