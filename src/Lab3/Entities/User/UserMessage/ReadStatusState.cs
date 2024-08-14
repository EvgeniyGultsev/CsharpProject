namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.User.UserMessage;

public abstract record ReadStatusState
{
    public sealed record Success : ReadStatusState;

    public sealed record Fail : ReadStatusState;
}