using Models.User;

namespace Abstractions.Repositories;

public interface IAdminRepository
{
    Task AddNewCard(User.Card card);
}