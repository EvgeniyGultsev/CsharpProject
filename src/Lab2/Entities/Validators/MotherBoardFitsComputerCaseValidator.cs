using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validators;

public class MotherBoardFitsComputerCaseValidator : IComputerValidator
{
    public ConfiguratorResult Validate(IComputerModel computer)
    {
        if (computer.MotherBoard is null)
            return new ConfiguratorResult.Failure(computer, new List<IComponent?> { computer.MotherBoard });
        if (computer.ComputerCase is null)
            return new ConfiguratorResult.Failure(computer, new List<IComponent?> { computer.ComputerCase });
        if (computer.ComputerCase.AcceptableFormFactors.Any(x => x == computer.MotherBoard.FormFactor))
            return new ConfiguratorResult.Success(computer);
        return new ConfiguratorResult.Failure(computer, new List<IComponent?> { computer.MotherBoard, computer.ComputerCase });
    }
}