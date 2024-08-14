using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Ram;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;

public record Chipset(IReadOnlyList<int> AcceptedMemoryFrequency, IReadOnlyList<XmpOrDocp> AcceptedProfiles);