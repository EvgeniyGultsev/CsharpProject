using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validators;

public class CoolerFitsCpuValidator : IComputerValidator
{
    public ConfiguratorResult Validate(IComputerModel computer)
    {
        if (computer.Cpu?.Tdp > computer.Cooler?.MaxTdp)
            return new ConfiguratorResult.SuccessWithWarnings(computer, computer.Cooler);
        return new ConfiguratorResult.Success(computer);
    }
}