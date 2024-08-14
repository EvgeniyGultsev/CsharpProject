using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validators;

public interface IComputerValidator
{
    public ConfiguratorResult Validate(IComputerModel computer);
}