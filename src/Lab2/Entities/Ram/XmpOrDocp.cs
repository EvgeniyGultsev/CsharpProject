using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Ram;

public record XmpOrDocp(IReadOnlyList<int> Timing, int Voltage, int Frequency, string Name) : IComponent;