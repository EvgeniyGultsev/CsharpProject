using Contracts.Logging;
using Contracts.Logging.AdminLogging;
using Models.Admin;
using Models.User;

namespace Application.Logging.AdminLogin;

public class AdminLoginService : IAdminLoginService
{
    private readonly CurrentUserManager _currentUserManager;
    private readonly AdminPassword _password;

    public AdminLoginService(CurrentUserManager currentUserManager, AdminPassword password)
    {
        _currentUserManager = currentUserManager;
        _password = password;
    }

    public Task<LoginResult> Login(string password)
    {
        if (password == _password.Password)
        {
            _currentUserManager.User = new User.Admin();
            return Task.FromResult<LoginResult>(new LoginResult.Success());
        }

        return Task.FromResult<LoginResult>(new LoginResult.Fail());
    }
}