using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validators;

public class CpuNotNullValidator : IComputerValidator
{
    public ConfiguratorResult Validate(IComputerModel computer)
    {
        if (computer.Cpu is null)
            return new ConfiguratorResult.Failure(computer, new List<IComponent?> { computer.Cpu });
        return new ConfiguratorResult.Success(computer);
    }
}