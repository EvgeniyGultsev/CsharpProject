using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;
using Itmo.ObjectOrientedProgramming.Lab4.Context;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Commands;

public class TreeGoToCommand : ICommand
{
    private readonly TreeGoToModel _data;

    public TreeGoToCommand(TreeGoToModel data)
    {
        _data = data;
    }

    public CommandExecutingResult Execute(IContext context)
    {
        if (context.System is NullFileSystem)
            return new CommandExecutingResult.Fail("No system to manage");
        context.RelationalWay = _data.Path;
        return new CommandExecutingResult.Success();
    }
}