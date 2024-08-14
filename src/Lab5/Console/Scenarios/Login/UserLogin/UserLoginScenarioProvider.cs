using System.Diagnostics.CodeAnalysis;
using Contracts.Logging;
using Contracts.Logging.UserLogging;

namespace Console.Scenarios.Login.UserLogin;

public class UserLoginScenarioProvider : IScenarioProvider
{
    private readonly IUserLoginService _service;
    private readonly ICurrentUserManager _currentUser;

    public UserLoginScenarioProvider(IUserLoginService service, ICurrentUserManager currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null)
        {
            scenario = new UserLoginScenario(_service);
            return true;
        }

        scenario = null;
        return false;
    }
}