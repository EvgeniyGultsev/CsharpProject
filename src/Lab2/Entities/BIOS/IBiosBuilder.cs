using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;

public interface IBiosBuilder
{
    public IBiosBuilder WithType(string type);
    public IBiosBuilder WithVersion(string version);
    public IBiosBuilder WithSupportedCpus(IEnumerable<ICpu> supportedCpus);
    public IBiosBuilder WithName(string name);
    public IBios Build();
}