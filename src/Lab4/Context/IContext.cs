using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeList.Visitor;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Context;

public interface IContext
{
    Signs Signs { get; }
    string RelationalWay { get; set; }
    IFileSystem System { get; set; }
}