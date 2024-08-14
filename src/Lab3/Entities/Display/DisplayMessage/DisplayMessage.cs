using Itmo.ObjectOrientedProgramming.Lab3.Entities.Display.Render;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display.DisplayMessage;

public class DisplayMessage : IDisplayMessage
{
    internal DisplayMessage(IText header, IText body)
    {
        Header = header;
        Body = body;
    }

    internal DisplayMessage()
    {
        Header = new Text(string.Empty);
        Body = new Text(string.Empty);
    }

    public IText Header { get; }
    public IText Body { get; }
}