using Itmo.ObjectOrientedProgramming.Lab4.Context;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Commands;

public interface ICommand
{
    public CommandExecutingResult Execute(IContext context);
}