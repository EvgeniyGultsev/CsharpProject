using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Cooler;

public class Cooler : ICooler
{
    internal Cooler(double height, IEnumerable<string> acceptableSockets, int maxTdp, string name)
    {
        Height = height;
        AcceptableSockets = acceptableSockets.ToList();
        MaxTdp = maxTdp;
        Name = name;
    }

    public double Height { get; }
    public IReadOnlyCollection<string> AcceptableSockets { get; }
    public int MaxTdp { get; }
    public string Name { get; }
    public void Direct(ICoolerBuilder builder)
    {
        builder.WithHeight(Height);
        builder.WithName(Name);
        builder.WithSockets(AcceptableSockets);
        builder.WithTdp(MaxTdp);
    }
}