namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Commands;

public abstract record CommandExecutingResult
{
    public sealed record Success : CommandExecutingResult;
    public sealed record Fail(string Message) : CommandExecutingResult;
}