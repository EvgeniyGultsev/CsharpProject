namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

public class Messenger : IMessenger
{
    private readonly IMessengerPrinter _printer;

    public Messenger(IMessengerPrinter printer)
    {
        _printer = printer;
    }

    public void GetMessage(MessengerMessage message)
    {
        _printer.Print(message);
    }
}