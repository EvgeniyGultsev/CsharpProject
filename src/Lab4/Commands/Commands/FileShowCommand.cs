using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;
using Itmo.ObjectOrientedProgramming.Lab4.Context;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Commands;

public class FileShowCommand : ICommand
{
    private readonly FileShowModel _data;

    public FileShowCommand(FileShowModel data)
    {
        _data = data;
    }

    public CommandExecutingResult Execute(IContext context)
    {
        if (context.System is NullFileSystem)
            return new CommandExecutingResult.Fail("No system to manage");
        string? fileText = null;
        if (context.System.FileExists(_data.Path))
        {
            fileText = context.System.FileShow(_data.Path);
        }

        if (context.System.FileExists(string.Concat(context.RelationalWay, _data.Path)))
        {
            fileText = context.System.FileShow(string.Concat(context.RelationalWay, _data.Path));
        }

        if (fileText is null)
            return new CommandExecutingResult.Fail("No file to operate");

        IWriter? writer = null;
        if (_data.Mode == Mode.Console)
        {
            writer = new ConsoleWriter();
        }

        if (writer is null)
            return new CommandExecutingResult.Fail("Wrong write mode");
        writer.Write(fileText);
        return new CommandExecutingResult.Success();
    }
}