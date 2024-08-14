using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validators;

public class VideoCardNotNullValidator : IComputerValidator
{
    public ConfiguratorResult Validate(IComputerModel computer)
    {
        if ((computer.Cpu?.VideoCore is null) && computer.VideoCard is null)
            return new ConfiguratorResult.Failure(computer, new List<IComponent?> { computer.VideoCard });
        return new ConfiguratorResult.Success(computer);
    }
}