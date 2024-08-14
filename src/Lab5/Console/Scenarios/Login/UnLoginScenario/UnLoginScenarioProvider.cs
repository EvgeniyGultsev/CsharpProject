using System.Diagnostics.CodeAnalysis;
using Contracts.Logging;
using Contracts.Logging.UnLogging;

namespace Console.Scenarios.Login.UnLoginScenario;

public class UnLoginScenarioProvider : IScenarioProvider
{
    private readonly IUnLoginService _service;
    private readonly ICurrentUserManager _currentUser;

    public UnLoginScenarioProvider(IUnLoginService service, ICurrentUserManager currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentUser.User is not null)
        {
            scenario = new UnLoginScenario(_service);
            return true;
        }

        scenario = null;
        return false;
    }
}