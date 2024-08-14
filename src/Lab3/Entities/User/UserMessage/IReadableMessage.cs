namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.User.UserMessage;

public interface IReadableMessage
{
    public string Header { get; }
    public string Body { get; }
    public bool Read { get; }
    public ReadStatusState SetMessageRead();
}