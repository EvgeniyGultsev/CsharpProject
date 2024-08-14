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

public class Computer : IComputer
{
    internal Computer(IComputerModel computerModel)
    {
        MotherBoard = computerModel.MotherBoard;
        Cpu = computerModel.Cpu;
        Cooler = computerModel.Cooler;
        Ram = computerModel.Ram;
        VideoCard = computerModel.VideoCard;
        Ssd = computerModel.Ssd;
        Hdd = computerModel.Hdd;
        ComputerCase = computerModel.ComputerCase;
        PowerSupply = computerModel.PowerSupply;
        WiFiModule = computerModel.WiFiModule;
    }

    public IMotherBoard? MotherBoard { get; }
    public ICpu? Cpu { get; }
    public ICooler? Cooler { get; }
    public IEnumerable<IRam> Ram { get; }
    public IDiscreteVideoCard? VideoCard { get; }
    public IEnumerable<ISsd> Ssd { get; }
    public IEnumerable<IHdd> Hdd { get; }
    public IComputerCase? ComputerCase { get; }
    public IPowerSupply? PowerSupply { get; }
    public IDiscreteWiFiModule? WiFiModule { get; }
    public void Direct(IComputerBuilder builder)
    {
        builder.WithMotherBoard(MotherBoard);
        builder.WithCpu(Cpu);
        builder.WithCooler(Cooler);
        builder.WithRam(Ram);
        builder.WithVideoCard(VideoCard);
        builder.WithSsd(Ssd);
        builder.WithHdd(Hdd);
        builder.WithComputerCase(ComputerCase);
        builder.WithPowerSupply(PowerSupply);
        builder.WithWifi(WiFiModule);
    }
}