using Itmo.ObjectOrientedProgramming.Lab3.Entities.Display.DisplayMessage;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public class Display : IDisplay
{
    private readonly IDisplayDriver _driver;

    public Display(IDisplayDriver driver)
    {
        _driver = driver;
    }

    public void GetMessage(IDisplayMessage message)
    {
        _driver.SetMessageColor(message);
        _driver.ClearOutput();
        _driver.PrintMessage(message);
    }
}