using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;

public interface ICpu : ICpuBuilderDirector, IComponent
{
    public int CoreFrequency { get; }
    public int CoreNumber { get; }
    public string Socket { get; }
    public IIntegratedVideoCard? VideoCore { get; }
    public IReadOnlyList<int> AcceptableRamFrequency { get; }
    public int Tdp { get; }
    public int Power { get; }
}