using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;

public interface IBios : IComponent, IBiosBuilderDirector
{
    public string Type { get; }
    public string Version { get; }
    public IReadOnlyList<ICpu> SupportedCpu { get; }
}