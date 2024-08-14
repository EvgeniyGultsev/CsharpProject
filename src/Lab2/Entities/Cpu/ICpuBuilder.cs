using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;

public interface ICpuBuilder
{
    public ICpuBuilder WithCoreFrequency(int coreFrequency);
    public ICpuBuilder WithCoreNumber(int coreNumber);
    public ICpuBuilder WithSocket(string socket);
    public ICpuBuilder WithVideoCore(IIntegratedVideoCard? core);
    public ICpuBuilder WithAcceptableRamFrequency(IEnumerable<int> acceptableRamFrequency);
    public ICpuBuilder WithTdp(int tdp);
    public ICpuBuilder WithPower(int power);
    public ICpuBuilder WithName(string name);
    public ICpu Build();
}