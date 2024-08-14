using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeList;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeList.Visitor;
using Itmo.ObjectOrientedProgramming.Lab4.Context;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Commands;

public class TreeListCommand : ICommand
{
    private readonly TreeListModel _data;

    public TreeListCommand(TreeListModel data)
    {
        _data = data;
    }

    public CommandExecutingResult Execute(IContext context)
    {
        if (context.System is NullFileSystem)
            return new CommandExecutingResult.Fail("No system to manage");
        if (context.System.DirectoryExists(context.RelationalWay) is false)
            return new CommandExecutingResult.Fail("No directory to manage");

        var treeTop = context.System.TreeList(context.RelationalWay, _data.Depth) as Directory;

        if (treeTop is null)
            return new CommandExecutingResult.Fail("Can't make tree");
        var tree = new StringBuilder();

        new Visitor(context.Signs).Visit(treeTop, tree);
        new ConsoleWriter().Write(tree.ToString());

        return new CommandExecutingResult.Success();
    }
}