using Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Display.DisplayMessage;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Address;

public class DisplayAddress : IAddress
{
    private readonly IDisplay _display;

    public DisplayAddress(IDisplay display)
    {
        _display = display;
    }

    public void SendMessage(Message message)
    {
        IDisplayMessageBuilder builder =
            new DisplayMessageBuilder().WithHeader(message.Header).WithBody(message.Body);
        _display.GetMessage(builder.Build());
    }
}