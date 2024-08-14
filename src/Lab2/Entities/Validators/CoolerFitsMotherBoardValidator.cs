using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validators;

public class CoolerFitsMotherBoardValidator : IComputerValidator
{
    public ConfiguratorResult Validate(IComputerModel computer)
    {
        if (computer.MotherBoard is null)
            return new ConfiguratorResult.Failure(computer, new List<IComponent?> { computer.MotherBoard });
        if (computer.Cooler is null)
            return new ConfiguratorResult.Failure(computer, new List<IComponent?> { computer.Cooler });
        if (!computer.Cooler.AcceptableSockets.Any(x => x.Equals(computer.MotherBoard.Socket, System.StringComparison.Ordinal)))
            return new ConfiguratorResult.Failure(computer, new List<IComponent?> { computer.Cooler, computer.MotherBoard });
        return new ConfiguratorResult.Success(computer);
    }
}