using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cooler;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Validators;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiModule;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

public class ComputerBuilder : IComputerBuilder
{
    private readonly IList<IComputerValidator> _validator;
    private IMotherBoard? _motherBoard;
    private ICpu? _cpu;
    private ICooler? _cooler;
    private IDiscreteVideoCard? _videoCard;
    private IList<IRam> _ram;
    private IList<ISsd> _ssd;
    private IList<IHdd> _hdd;
    private IComputerCase? _computerCase;
    private IPowerSupply? _powerSupply;
    private IDiscreteWiFiModule? _wiFiModule;

    public ComputerBuilder(IEnumerable<IComputerValidator> validator)
    {
        _ssd = new List<ISsd>();
        _hdd = new List<IHdd>();
        _validator = validator.ToList();
        _ram = new List<IRam>();
    }

    public IComputerBuilder WithMotherBoard(IMotherBoard? motherBoard)
    {
        _motherBoard = motherBoard;
        return this;
    }

    public IComputerBuilder WithCpu(ICpu? cpu)
    {
        _cpu = cpu;
        return this;
    }

    public IComputerBuilder WithCooler(ICooler? cooler)
    {
        _cooler = cooler;
        return this;
    }

    public IComputerBuilder WithRam(IEnumerable<IRam> ram)
    {
        _ram = ram.ToList();
        return this;
    }

    public IComputerBuilder WithVideoCard(IDiscreteVideoCard? videoCard)
    {
        _videoCard = videoCard;
        return this;
    }

    public IComputerBuilder WithSsd(IEnumerable<ISsd> ssd)
    {
        _ssd = ssd.ToList();
        return this;
    }

    public IComputerBuilder WithHdd(IEnumerable<IHdd> hdd)
    {
        _hdd = hdd.ToList();
        return this;
    }

    public IComputerBuilder WithComputerCase(IComputerCase? computerCase)
    {
        _computerCase = computerCase;
        return this;
    }

    public IComputerBuilder WithPowerSupply(IPowerSupply? powerSupply)
    {
        _powerSupply = powerSupply;
        return this;
    }

    public IComputerBuilder WithWifi(IDiscreteWiFiModule? wiFiModule)
    {
        _wiFiModule = wiFiModule;
        return this;
    }

    public ConfiguratorResult Build()
    {
        IComputerModel model = new ComputerModel(
            _motherBoard,
            _cpu,
            _cooler,
            _ram,
            _videoCard,
            _ssd,
            _hdd,
            _computerCase,
            _powerSupply,
            _wiFiModule);

        IComponent? warningComponent = null;
        foreach (IComputerValidator validator in _validator)
        {
            ConfiguratorResult temporaryConfiguratorResult = validator.Validate(model);
            switch (temporaryConfiguratorResult)
            {
                case ConfiguratorResult.Failure:
                    return temporaryConfiguratorResult;
                case ConfiguratorResult.SuccessWithWarnings result:
                    warningComponent = result.Component;
                    break;
                default:
                    break;
            }
        }

        IComputer computer = new Computer(model);
        if (warningComponent is not null)
            return new ConfiguratorResult.SuccessWithWarnings(computer, warningComponent);
        return new ConfiguratorResult.Success(computer);
    }
}