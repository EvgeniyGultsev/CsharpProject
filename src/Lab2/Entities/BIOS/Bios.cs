using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;

public class Bios : IBios
{
    internal Bios(string type, string version, IEnumerable<ICpu> supportedCpu, string name)
    {
        Type = type;
        Version = version;
        Name = name;
        SupportedCpu = supportedCpu.ToList();
    }

    public string Type { get; }
    public string Version { get; }
    public IReadOnlyList<ICpu> SupportedCpu { get; }
    public string Name { get; }

    public void Direct(IBiosBuilder builder)
    {
        builder.WithType(Type);
        builder.WithVersion(Version);
        builder.WithSupportedCpus(SupportedCpu);
        builder.WithName(Name);
    }
}