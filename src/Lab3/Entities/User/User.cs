using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.User.UserMessage;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.User;

public class User : IUser
{
    private readonly IList<IReadableMessage> _messages = new List<IReadableMessage>();

    public User(int userId)
    {
        UserId = userId;
    }

    public int UserId { get; }
    public void GetMessage(Message message)
    {
        _messages.Add(new ReadableMessage(message));
    }

    public ReadStatusState SetMessageRead(string messageName)
    {
        if (_messages.Any(x => x.Header == messageName))
        {
            return _messages.First(x => x.Header == messageName).SetMessageRead();
        }

        return new ReadStatusState.Fail();
    }

    public IReadableMessage? FindMessage(string header)
    {
        return _messages.FirstOrDefault(x => x.Header == header);
    }
}