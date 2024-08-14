using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;
using Itmo.ObjectOrientedProgramming.Lab4.Context;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Commands;

public class FileRenameCommand : ICommand
{
    private readonly FileRenameModel _data;

    public FileRenameCommand(FileRenameModel data)
    {
        _data = data;
    }

    public CommandExecutingResult Execute(IContext context)
    {
        if (context.System is NullFileSystem)
            return new CommandExecutingResult.Fail("No system to manage");
        string? filePath = null;
        if (context.System.FileExists(_data.Path))
        {
            filePath = _data.Path;
        }
        else
        {
            if (context.System.FileExists(string.Concat(context.RelationalWay, _data.Path)))
                filePath = string.Concat(context.RelationalWay, _data.Path);
        }

        if (filePath is null)
            return new CommandExecutingResult.Fail("No file to operate");
        if (context.System.Rename(filePath, _data.Name) is ResultSystemOperation.Success)
            return new CommandExecutingResult.Success();
        return new CommandExecutingResult.Fail("file wasn't renamed");
    }
}