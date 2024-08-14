using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validators;

public class PowerSupplyNotNullValidator : IComputerValidator
{
    public ConfiguratorResult Validate(IComputerModel computer)
    {
        if (computer.PowerSupply is null)
            return new ConfiguratorResult.Failure(computer, new List<IComponent?> { computer.PowerSupply });
        return new ConfiguratorResult.Success(computer);
    }
}