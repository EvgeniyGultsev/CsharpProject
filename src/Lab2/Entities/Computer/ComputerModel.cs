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

public class ComputerModel : IComputerModel
{
    internal ComputerModel(IMotherBoard? motherBoard, ICpu? cpu, ICooler? cooler, IEnumerable<IRam> ram, IDiscreteVideoCard? videoCard, IEnumerable<ISsd> ssd, IEnumerable<IHdd> hdd, IComputerCase? computerCase, IPowerSupply? powerSupply, IDiscreteWiFiModule? wiFiModule)
    {
        MotherBoard = motherBoard;
        Cpu = cpu;
        Cooler = cooler;
        Ram = ram;
        VideoCard = videoCard;
        Ssd = ssd;
        Hdd = hdd;
        ComputerCase = computerCase;
        PowerSupply = powerSupply;
        WiFiModule = wiFiModule;
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
}