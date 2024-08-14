using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Address;

public class MessengerAddress : IAddress
{
    private readonly IMessenger _messenger;

    public MessengerAddress(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void SendMessage(Message message)
    {
        _messenger.GetMessage(new MessengerMessage(message.Body, message.Header));
    }
}