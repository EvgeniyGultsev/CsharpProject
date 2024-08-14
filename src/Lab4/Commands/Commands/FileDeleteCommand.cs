using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;
using Itmo.ObjectOrientedProgramming.Lab4.Context;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Commands;

public class FileDeleteCommand : ICommand
{
    private readonly FileDeleteModel _data;

    public FileDeleteCommand(FileDeleteModel data)
    {
        _data = data;
    }

    public CommandExecutingResult Execute(IContext context)
    {
        if (context.System is NullFileSystem)
            return new CommandExecutingResult.Fail("No system to manage");
        if (context.System.FileExists(_data.Path))
        {
            if (context.System.Delete(_data.Path) is ResultSystemOperation.Fail)
                return new CommandExecutingResult.Fail("Isn't able to delete");
            return new CommandExecutingResult.Success();
        }

        if (context.System.FileExists(string.Concat(context.RelationalWay, _data.Path)))
        {
            if (context.System.Delete(string.Concat(context.RelationalWay, _data.Path)) is ResultSystemOperation.Fail)
                return new CommandExecutingResult.Fail("Isn't able to delete");
            return new CommandExecutingResult.Success();
        }

        return new CommandExecutingResult.Fail("Path Doesn't Exist");
    }
}