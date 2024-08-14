using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validators;

public class EnoughRamSlotsValidator : IComputerValidator
{
    public ConfiguratorResult Validate(IComputerModel computer)
    {
        if (computer.Ram.Count() > computer.MotherBoard?.RamNumber)
        {
            var componentRejectResult = new List<IComponent?> { computer.MotherBoard };
            componentRejectResult.AddRange(computer.Ram);
            return new ConfiguratorResult.Failure(computer, componentRejectResult);
        }

        return new ConfiguratorResult.Success(computer);
    }
}