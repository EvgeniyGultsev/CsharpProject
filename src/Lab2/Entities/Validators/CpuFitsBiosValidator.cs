using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validators;

public class CpuFitsBiosValidator : IComputerValidator
{
    public ConfiguratorResult Validate(IComputerModel computer)
    {
        if (computer.MotherBoard?.Bios.SupportedCpu.Any(x => x.Name.Equals(computer.Cpu?.Name, System.StringComparison.Ordinal)) is false)
        {
            return new ConfiguratorResult.Failure(computer, new List<IComponent?> { computer.MotherBoard, computer.Cpu });
        }

        return new ConfiguratorResult.Success(computer);
    }
}