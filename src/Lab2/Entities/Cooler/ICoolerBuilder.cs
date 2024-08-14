using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Cooler;

public interface ICoolerBuilder
{
    public ICoolerBuilder WithHeight(double height);
    public ICoolerBuilder WithSockets(IEnumerable<string> sokets);
    public ICoolerBuilder WithTdp(int tdp);
    public ICoolerBuilder WithName(string name);
    public ICooler Build();
}