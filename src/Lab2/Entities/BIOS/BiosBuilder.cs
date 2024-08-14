using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;

public class BiosBuilder : IBiosBuilder
{
    private string? _type;
    private string? _version;
    private IEnumerable<ICpu>? _supportedCpu;
    private string? _name;
    public IBiosBuilder WithType(string type)
    {
        _type = type;
        return this;
    }

    public IBiosBuilder WithVersion(string version)
    {
        _version = version;
        return this;
    }

    public IBiosBuilder WithSupportedCpus(IEnumerable<ICpu> supportedCpus)
    {
        _supportedCpu = new List<ICpu>(supportedCpus);
        return this;
    }

    public IBiosBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IBios Build()
    {
        return new Bios(
            _type ?? throw new ArgumentNullException(),
            _version ?? throw new ArgumentNullException(),
            _supportedCpu ?? throw new ArgumentNullException(),
            _name ?? throw new ArgumentNullException());
    }
}