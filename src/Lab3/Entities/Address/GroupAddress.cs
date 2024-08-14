using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Address;

public class GroupAddress : IAddress
{
    private readonly IList<IAddress> _addresses;

    public GroupAddress(IList<IAddress> addresses)
    {
        _addresses = addresses;
    }

    public void SendMessage(Message message)
    {
        foreach (IAddress address in _addresses)
        {
            address.SendMessage(message);
        }
    }
}