using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;
using Itmo.ObjectOrientedProgramming.Lab4.Context;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Commands;

public class DisconnectCommand : ICommand
{
    private readonly DisconnectModel _data;

    public DisconnectCommand(DisconnectModel data)
    {
        _data = data;
    }

    public CommandExecutingResult Execute(IContext context)
    {
        context.System = new NullFileSystem();
        return new CommandExecutingResult.Success();
    }
}