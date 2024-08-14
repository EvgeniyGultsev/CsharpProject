namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Topic;

public interface ITopic
{
    public string Name { get; }
    public void SendMessage(Message message);
}