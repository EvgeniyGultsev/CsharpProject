using Abstractions.Repositories;
using Contracts.AdminActions;
using Models.User;

namespace Application.AdminActions;

public class AddUserAction : IAddUser
{
    private readonly IAdminRepository _repository;

    public AddUserAction(IAdminRepository repository)
    {
        _repository = repository;
    }

    public Task AddUser(long cardId, int pinCode)
    {
        _repository.AddNewCard(new User.Card(cardId, pinCode));
        return Task.CompletedTask;
    }
}