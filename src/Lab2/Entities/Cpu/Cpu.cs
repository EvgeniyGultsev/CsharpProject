using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;

public class Cpu : ICpu
{
    internal Cpu(int coreFrequency, int coreNumber, string socket, IIntegratedVideoCard? videoCore, IReadOnlyList<int> acceptableRamFrequency, int tdp, int power, string name)
    {
        CoreFrequency = coreFrequency;
        CoreNumber = coreNumber;
        Socket = socket;
        VideoCore = videoCore;
        AcceptableRamFrequency = acceptableRamFrequency;
        Tdp = tdp;
        Power = power;
        Name = name;
    }

    public int CoreFrequency { get; }
    public int CoreNumber { get; }
    public string Socket { get; }
    public IIntegratedVideoCard? VideoCore { get; }
    public IReadOnlyList<int> AcceptableRamFrequency { get; }
    public int Tdp { get; }
    public int Power { get; }
    public string Name { get; }

    public void Direct(ICpuBuilder builder)
    {
        builder.WithCoreFrequency(CoreFrequency);
        builder.WithCoreNumber(CoreNumber);
        builder.WithSocket(Socket);
        builder.WithVideoCore(VideoCore);
        builder.WithAcceptableRamFrequency(AcceptableRamFrequency);
        builder.WithTdp(Tdp);
        builder.WithPower(Power);
        builder.WithName(Name);
    }
}