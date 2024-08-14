using Models.User;

namespace Contracts.Logging.UserLogging;

public interface IUserLoginService
{
    Task<LoginResult> Login(User.Card card);
}