using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;
using Itmo.ObjectOrientedProgramming.Lab4.Context;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Commands;

public class FileCopyCommand : ICommand
{
    private readonly FileCopyModel _data;

    public FileCopyCommand(FileCopyModel data)
    {
        _data = data;
    }

    public CommandExecutingResult Execute(IContext context)
    {
        if (context.System is NullFileSystem)
            return new CommandExecutingResult.Fail("No system to manage");
        string? sourcePath = null;
        if (context.System.FileExists(_data.SourcePath))
        {
            sourcePath = _data.SourcePath;
        }
        else
        {
            if (context.System.FileExists(string.Concat(context.RelationalWay, _data.SourcePath)))
                sourcePath = string.Concat(context.RelationalWay, _data.SourcePath);
        }

        string? endPath = null;
        if (context.System.DirectoryExists(_data.DestinationPath))
        {
            endPath = _data.DestinationPath;
        }
        else
        {
            if (context.System.DirectoryExists(string.Concat(context.RelationalWay, _data.DestinationPath)))
                endPath = string.Concat(context.RelationalWay, _data.DestinationPath);
        }

        if (sourcePath is null || endPath is null)
            return new CommandExecutingResult.Fail("No source file");

        if (context.System.Copy(sourcePath, endPath) is ResultSystemOperation.Success)
            return new CommandExecutingResult.Success();
        return new CommandExecutingResult.Fail("Didn't copy");
    }
}