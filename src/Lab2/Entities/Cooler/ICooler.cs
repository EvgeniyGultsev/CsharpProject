using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Cooler;

public interface ICooler : IComponent, ICoolerBuilderDirector
{
    public double Height { get; }
    public IReadOnlyCollection<string> AcceptableSockets { get; }
    public int MaxTdp { get; }
}