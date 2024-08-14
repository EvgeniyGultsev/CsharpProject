using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validators;

public class WifiFitsMotherBoardValidator : IComputerValidator
{
    public ConfiguratorResult Validate(IComputerModel computer)
    {
        if (computer.MotherBoard?.WifiModule is not null && computer.WiFiModule is not null)
            return new ConfiguratorResult.Failure(computer, new List<IComponent?> { computer.WiFiModule, computer.MotherBoard });
        return new ConfiguratorResult.Success(computer);
    }
}