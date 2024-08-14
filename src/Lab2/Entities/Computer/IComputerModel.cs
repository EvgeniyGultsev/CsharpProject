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

public interface IComputerModel
{
    IMotherBoard? MotherBoard { get; }
    ICpu? Cpu { get; }
    ICooler? Cooler { get; }
    IEnumerable<IRam> Ram { get; }
    IDiscreteVideoCard? VideoCard { get; }
    IEnumerable<ISsd> Ssd { get; }
    IEnumerable<IHdd> Hdd { get; }
    IComputerCase? ComputerCase { get; }
    IPowerSupply? PowerSupply { get; }
    IDiscreteWiFiModule? WiFiModule { get; }
}