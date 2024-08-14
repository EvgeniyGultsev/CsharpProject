using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validators;

public class PowerSupplyFitsComputerValidator : IComputerValidator
{
    public ConfiguratorResult Validate(IComputerModel computer)
    {
        int tmpPower = 0;
        if (computer.Cpu is null)
            return new ConfiguratorResult.Failure(computer, new List<IComponent?> { computer.Cpu });
        tmpPower += computer.Cpu.Power + computer.Ram.Sum(x => x.Power);
        if (computer.VideoCard is not null)
            tmpPower += computer.VideoCard.NeededPower;
        tmpPower += computer.Ssd.Sum(x => x.Power);
        tmpPower += computer.Hdd.Sum(x => x.Power);
        if (computer.WiFiModule is not null)
            tmpPower += computer.WiFiModule.Power;
        if (tmpPower <= 1.2 * computer.PowerSupply?.Power && tmpPower > computer.PowerSupply?.Power)
            return new ConfiguratorResult.SuccessWithWarnings(computer, computer.PowerSupply);
        if (tmpPower > 1.2 * computer.PowerSupply?.Power)
            return new ConfiguratorResult.Failure(computer, new List<IComponent?> { computer.PowerSupply });
        return new ConfiguratorResult.Success(computer);
    }
}