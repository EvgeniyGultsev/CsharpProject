using Itmo.ObjectOrientedProgramming.Lab3.Entities.Display.Render;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display.DisplayMessage;

public interface IDisplayMessage
{
    public IText Header { get; }
    public IText Body { get; }
}