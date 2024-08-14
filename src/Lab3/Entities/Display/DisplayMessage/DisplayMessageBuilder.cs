using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Display.Render;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display.DisplayMessage;

public class DisplayMessageBuilder : IDisplayMessageBuilder
{
    private IText? _header;
    private IText? _body;
    public IDisplayMessageBuilder WithHeader(string header)
    {
        _header = new Text(header);
        return this;
    }

    public IDisplayMessageBuilder WithBody(string body)
    {
        _body = new Text(body);
        return this;
    }

    public IDisplayMessage Build()
    {
        return new DisplayMessage(
            _header ?? throw new ArgumentNullException(),
            _body ?? throw new ArgumentNullException());
    }
}