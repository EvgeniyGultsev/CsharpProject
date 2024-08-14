using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Display.DisplayMessage;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Display.Render;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public sealed class FileDriver : IDisplayDriver
{
    private readonly string _path;
    private readonly IModifier _colorModifier;

    public FileDriver(string path, IModifier colorModifier)
    {
        _colorModifier = colorModifier;
        _path = path;
    }

    public void PrintMessage(IDisplayMessage message)
    {
        var writer = new StreamWriter(_path);
        writer.WriteLine(message.Header);
        writer.WriteLine(message.Body);
        writer.Dispose();
    }

    public void ClearOutput()
    {
        var writer = new StreamWriter(_path);
        writer.WriteLine(string.Empty);
        writer.Dispose();
    }

    public void SetMessageColor(IDisplayMessage message)
    {
        message.Body.SetModifier(_colorModifier);
        message.Header.SetModifier(_colorModifier);
    }
}