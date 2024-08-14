using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validators;

public class RamNotEmptyValidator : IComputerValidator
{
    public ConfiguratorResult Validate(IComputerModel computer)
    {
        if (!computer.Ram.Any())
            return new ConfiguratorResult.Failure(computer, new List<IComponent?>(computer.Ram));
        return new ConfiguratorResult.Success(computer);
    }
}