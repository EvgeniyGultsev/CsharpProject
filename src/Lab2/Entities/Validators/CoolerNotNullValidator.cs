using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validators;

public class CoolerNotNullValidator : IComputerValidator
{
    public ConfiguratorResult Validate(IComputerModel computer)
    {
        if (computer.Cooler is null)
            return new ConfiguratorResult.Failure(computer, new List<IComponent?> { computer.Cooler });
        return new ConfiguratorResult.Success(computer);
    }
}