using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Display.DisplayMessage;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Display.Render;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public class ConsoleDriver : IDisplayDriver
{
    private readonly IModifier _colorModifier;
    public ConsoleDriver(IModifier colorModifier)
    {
        _colorModifier = colorModifier;
    }

    public void PrintMessage(IDisplayMessage message)
    {
        Console.WriteLine(message.Header);
        Console.WriteLine(message.Body);
    }

    public void ClearOutput()
    {
        Console.Clear();
    }

    public void SetMessageColor(IDisplayMessage message)
    {
        message.Body.SetModifier(_colorModifier);
        message.Header.SetModifier(_colorModifier);
    }
}