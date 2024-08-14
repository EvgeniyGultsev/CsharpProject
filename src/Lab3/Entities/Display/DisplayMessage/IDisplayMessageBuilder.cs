namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display.DisplayMessage;

public interface IDisplayMessageBuilder
{
    public IDisplayMessageBuilder WithHeader(string header);
    public IDisplayMessageBuilder WithBody(string body);
    public IDisplayMessage Build();
}