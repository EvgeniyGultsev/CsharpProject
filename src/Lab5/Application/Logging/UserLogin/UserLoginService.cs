using Abstractions.Repositories;
using Contracts.Logging;
using Contracts.Logging.UserLogging;
using Models.User;

namespace Application.Logging.UserLogin;

public class UserLoginService : IUserLoginService
{
    private readonly ICardRepository _repository;
    private readonly CurrentUserManager _currentUserManager;

    public UserLoginService(ICardRepository repository, CurrentUserManager currentUserManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
    }

    public async Task<LoginResult> Login(User.Card card)
    {
        User.Card? user = await _repository.FindCardById(card.CardId);
        if (user is null || user.PinCode != card.PinCode)
            return new LoginResult.Fail();

        _currentUserManager.User = user;
        return new LoginResult.Success();
    }
}