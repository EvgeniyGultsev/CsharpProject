namespace Contracts.AdminActions;

public interface IAddUser
{
    Task AddUser(long cardId, int pinCode);
}