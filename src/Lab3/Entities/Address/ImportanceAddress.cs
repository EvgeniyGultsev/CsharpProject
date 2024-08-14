namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Address;

public class ImportanceAddress : IAddress
{
    private readonly int _priority;
    private readonly IAddress _address;

    public ImportanceAddress(IAddress address, int priority)
    {
        _address = address;
        _priority = priority;
    }

    public void SendMessage(Message message)
    {
        if (_priority > message.ImportanceLevel)
            return;
        _address.SendMessage(message);
    }
}