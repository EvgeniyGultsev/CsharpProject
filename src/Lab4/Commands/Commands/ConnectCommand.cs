using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsModels;
using Itmo.ObjectOrientedProgramming.Lab4.Context;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Commands;

public class ConnectCommand : ICommand
{
    private readonly ConnectModel _data;

    public ConnectCommand(ConnectModel data)
    {
        _data = data;
    }

    public CommandExecutingResult Execute(IContext context)
    {
        switch (_data.MFlag)
        {
            case Mode.Local:
            {
                context.System = new LocalFileSystem(_data.Address);
                return new CommandExecutingResult.Success();
            }

            default:
                return new CommandExecutingResult.Fail("No such type of system");
        }
    }
}