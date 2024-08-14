using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validators;

public class CoolerFitsCaseValidator : IComputerValidator
{
    public ConfiguratorResult Validate(IComputerModel computer)
    {
        if (computer.Cooler?.Height + 5 > computer.ComputerCase?.Width)
            return new ConfiguratorResult.Failure(computer, new List<IComponent?> { computer.Cooler, computer.ComputerCase });
        return new ConfiguratorResult.Success(computer);
    }
}