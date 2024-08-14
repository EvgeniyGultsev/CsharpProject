namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers;

public abstract record ParsingArgumentResult()
{
    public sealed record Success() : ParsingArgumentResult();

    public sealed record Fail() : ParsingArgumentResult;
}