using Contracts.Logging.UnLogging;
using Spectre.Console;

namespace Console.Scenarios.Login.UnLoginScenario;

public class UnLoginScenario : IScenario
{
    private readonly IUnLoginService _unLoginService;

    public UnLoginScenario(IUnLoginService unLoginService)
    {
        _unLoginService = unLoginService;
    }

    public string Name => "UnLogin";
    public Task Run()
    {
        _unLoginService.UnLogin();
        AnsiConsole.WriteLine("UnLogin");
        AnsiConsole.Ask<string>("OK");
        return Task.CompletedTask;
    }
}