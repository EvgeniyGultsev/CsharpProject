using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validators;

public class MotherBoardNotNullValidator : IComputerValidator
{
    public ConfiguratorResult Validate(IComputerModel computer)
    {
        if (computer.MotherBoard is null)
            return new ConfiguratorResult.Failure(computer, new List<IComponent?> { computer.MotherBoard });
        return new ConfiguratorResult.Success(computer);
    }
}