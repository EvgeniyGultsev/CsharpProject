using Itmo.ObjectOrientedProgramming.Lab3.Entities.Display.DisplayMessage;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public interface IDisplayDriver
{
    public void PrintMessage(IDisplayMessage message);
    public void ClearOutput();
    public void SetMessageColor(IDisplayMessage message);
}