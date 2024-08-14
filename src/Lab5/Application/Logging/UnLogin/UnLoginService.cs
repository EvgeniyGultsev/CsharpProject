using Contracts.Logging.UnLogging;

namespace Application.Logging.UnLogin;

public class UnLoginService : IUnLoginService
{
    private readonly CurrentUserManager _currentUserManager;

    public UnLoginService(CurrentUserManager currentUserManager)
    {
        _currentUserManager = currentUserManager;
    }

    public Task UnLogin()
    {
        _currentUserManager.User = null;
        return Task.CompletedTask;
    }
}