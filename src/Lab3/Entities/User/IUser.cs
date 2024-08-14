using Itmo.ObjectOrientedProgramming.Lab3.Entities.User.UserMessage;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.User;

public interface IUser
{
    public void GetMessage(Message message);
    public ReadStatusState SetMessageRead(string messageName);
    public IReadableMessage? FindMessage(string header);
}