using System.Diagnostics.CodeAnalysis;
using Contracts.Logging;
using Contracts.Logging.AdminLogging;

namespace Console.Scenarios.Login.AdminLogin;

public class AdminLoginScenarioProvider : IScenarioProvider
{
    private readonly IAdminLoginService _service;
    private readonly ICurrentUserManager _currentUser;

    public AdminLoginScenarioProvider(ICurrentUserManager currentUser, IAdminLoginService service)
    {
        _currentUser = currentUser;
        _service = service;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentUser.User is null)
        {
            scenario = new AdminLoginScenario(_service);
            return true;
        }

        scenario = null;
        return false;
    }
}