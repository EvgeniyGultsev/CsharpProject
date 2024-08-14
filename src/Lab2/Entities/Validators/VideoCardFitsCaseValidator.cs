using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validators;

public class VideoCardFitsCaseValidator : IComputerValidator
{
    public ConfiguratorResult Validate(IComputerModel computer)
    {
        if (computer.VideoCard != null && computer.VideoCard.Width >= computer.ComputerCase?.MaxVideoCardWidth)
            return new ConfiguratorResult.Failure(computer, new List<IComponent?> { computer.VideoCard, computer.ComputerCase });
        if (computer.VideoCard != null && computer.VideoCard.Length >= computer.ComputerCase?.MaxVideoCardLength)
            return new ConfiguratorResult.Failure(computer, new List<IComponent?> { computer.VideoCard, computer.ComputerCase });
        return new ConfiguratorResult.Success(computer);
    }
}