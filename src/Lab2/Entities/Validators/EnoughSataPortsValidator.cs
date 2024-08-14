using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validators;

public class EnoughSataPortsValidator : IComputerValidator
{
    public ConfiguratorResult Validate(IComputerModel computer)
    {
        int sataNumber = 0;
        sataNumber += computer.Ssd.Count(x => x.ConnectionVersion == ConnectionVersion.Sata);
        sataNumber += computer.Hdd.Count();
        if (sataNumber > computer.MotherBoard?.SataPorts)
        {
            var componentRejectResult = new List<IComponent?> { computer.MotherBoard };
            componentRejectResult.AddRange(computer.Ssd.Where(x => x.ConnectionVersion == ConnectionVersion.Sata));
            componentRejectResult.AddRange(computer.Hdd);
            return new ConfiguratorResult.Failure(computer, componentRejectResult);
        }

        return new ConfiguratorResult.Success(computer);
    }
}