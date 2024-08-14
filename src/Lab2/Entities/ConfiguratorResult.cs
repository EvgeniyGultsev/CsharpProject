using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public abstract record ConfiguratorResult(IComputerModel Computer)
{
    public sealed record Success(IComputerModel Computer) : ConfiguratorResult(Computer);
    public sealed record SuccessWithWarnings(IComputerModel Computer, IComponent Component) : ConfiguratorResult(Computer);
    public sealed record Failure(IComputerModel Computer, IList<IComponent?> RejectedComponents) : ConfiguratorResult(Computer);
}