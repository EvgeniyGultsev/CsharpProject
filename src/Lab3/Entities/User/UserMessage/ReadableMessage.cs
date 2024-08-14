namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.User.UserMessage;

public class ReadableMessage : IReadableMessage
{
    private bool _readThisMessage;
    public ReadableMessage(Message message)
    {
        Header = message.Header;
        Body = message.Body;
        _readThisMessage = false;
    }

    public bool Read => _readThisMessage;

    public string Header { get; }
    public string Body { get; }
    public ReadStatusState SetMessageRead()
    {
        if (_readThisMessage is false)
        {
            _readThisMessage = true;
            return new ReadStatusState.Success();
        }

        return new ReadStatusState.Fail();
    }
}