using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validators;

public class ComputerCaseNotNullValidator : IComputerValidator
{
    public ConfiguratorResult Validate(IComputerModel computer)
    {
        if (computer.ComputerCase is null)
            return new ConfiguratorResult.Failure(computer, new List<IComponent?> { computer.ComputerCase });
        return new ConfiguratorResult.Success(computer);
    }
}