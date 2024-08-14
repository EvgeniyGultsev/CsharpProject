using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validators;

public class EnoughPciPortsValidator : IComputerValidator
{
    public ConfiguratorResult Validate(IComputerModel computer)
    {
        int pciENumber = 0;
        if (computer.VideoCard is not null) pciENumber++;
        if (computer.WiFiModule is not null) pciENumber++;
        pciENumber += computer.Ssd.Count(x => x.ConnectionVersion == ConnectionVersion.PciE);
        if (computer.MotherBoard != null && pciENumber > computer.MotherBoard.PciELines)
        {
            var componentRejectResult = new List<IComponent?>();
            componentRejectResult.Add(computer.MotherBoard);
            componentRejectResult.Add(computer.VideoCard);
            componentRejectResult.Add(computer.WiFiModule);
            componentRejectResult.AddRange(computer.Ssd.Where(x => x.ConnectionVersion == ConnectionVersion.PciE));
            return new ConfiguratorResult.Failure(computer, componentRejectResult);
        }

        return new ConfiguratorResult.Success(computer);
    }
}