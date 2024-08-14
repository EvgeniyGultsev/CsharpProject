using Itmo.ObjectOrientedProgramming.Lab3.Entities.Display.DisplayMessage;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public interface IDisplay
{
    public void GetMessage(IDisplayMessage message);
}