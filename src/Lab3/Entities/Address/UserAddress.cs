using Itmo.ObjectOrientedProgramming.Lab3.Entities.User;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Address;

public class UserAddress : IAddress
{
    private readonly IUser _user;

    public UserAddress(IUser user)
    {
        _user = user;
    }

    public void SendMessage(Message message)
    {
        _user.GetMessage(message);
    }
}