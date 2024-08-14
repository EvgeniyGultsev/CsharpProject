using Itmo.ObjectOrientedProgramming.Lab4.Commands.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.ParsingCommandChains;

public abstract record ParsingResult()
{
    public sealed record Success(ICommand Command) : ParsingResult;

    public sealed record Fail() : ParsingResult;
}