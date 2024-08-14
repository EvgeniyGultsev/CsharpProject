using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validators;

public class CpuFitsMotherBoardValidator : IComputerValidator
{
    public ConfiguratorResult Validate(IComputerModel computer)
    {
        if (computer.MotherBoard?.Socket.Equals(computer.Cpu?.Socket, System.StringComparison.Ordinal) is false)
        {
            return new ConfiguratorResult.Failure(computer, new List<IComponent?> { computer.MotherBoard, computer.Cpu });
        }

        return new ConfiguratorResult.Success(computer);
    }
}