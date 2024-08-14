using Itmo.ObjectOrientedProgramming.Lab3.Entities.Address;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Topic;

public class Topic : ITopic
{
    private readonly IAddress _address;
    public Topic(string name, IAddress address)
    {
        Name = name;
        _address = address;
    }

    public string Name { get; }
    public void SendMessage(Message message)
    {
        _address.SendMessage(message);
    }
}