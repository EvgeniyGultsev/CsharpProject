using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validators;

public class RamFitsMotherBoardValidator : IComputerValidator
{
    public ConfiguratorResult Validate(IComputerModel computer)
    {
        if (computer.Ram.Any(x => x.DdrType != computer.MotherBoard?.DdrType))
        {
            var rejectedComponents = new List<IComponent?> { computer.MotherBoard };
            rejectedComponents.AddRange(computer.Ram);
            return new ConfiguratorResult.Failure(computer, rejectedComponents);
        }

        if (computer.Ram.Any(x => x.AcceptedFrequency.Max() < computer.MotherBoard?.Chipset.AcceptedMemoryFrequency.Min()))
        {
            var rejectedComponents = new List<IComponent?> { computer.MotherBoard };
            rejectedComponents.AddRange(computer.Ram);
            return new ConfiguratorResult.Failure(computer, rejectedComponents);
        }

        return new ConfiguratorResult.Success(computer);
    }
}