using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeList.Visitor;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Context;

public class Context : IContext
{
    public Context(Signs signs)
    {
        Signs = signs;
        RelationalWay = string.Empty;
        System = new NullFileSystem();
    }

    public Signs Signs { get; }
    public string RelationalWay { get; set; }
    public IFileSystem System { get; set; }
}