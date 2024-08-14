namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public abstract record ResultSystemOperation
{
    public sealed record Success() : ResultSystemOperation();
    public sealed record Fail() : ResultSystemOperation();
}