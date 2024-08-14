using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Ram;

public interface IRam : IComponent, IRamBuilderDirector
{
    public int Storage { get; }
    public IReadOnlyList<int> AcceptedFrequency { get; }
    public IReadOnlyList<int> AcceptedVoltage { get; }
    public IReadOnlyList<XmpOrDocp> Profiles { get; }
    public RamFormFactor RamFormFactor { get; }
    public DdrType DdrType { get; }
    public int Power { get; }
}