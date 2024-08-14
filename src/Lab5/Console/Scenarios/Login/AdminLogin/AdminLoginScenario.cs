using Contracts.Logging;
using Contracts.Logging.AdminLogging;
using Spectre.Console;

namespace Console.Scenarios.Login.AdminLogin;

public class AdminLoginScenario : IScenario
{
    private readonly IAdminLoginService _adminLoginService;

    public AdminLoginScenario(IAdminLoginService adminLoginService)
    {
        _adminLoginService = adminLoginService;
    }

    public string Name => "Admin Login";
    public async Task Run()
    {
        string password = AnsiConsole.Ask<string>("Enter your admin password");
        LoginResult result = await _adminLoginService.Login(password);
        switch (result)
        {
            case LoginResult.Success:
                AnsiConsole.WriteLine("Successful login");
                AnsiConsole.Ask<string>("Ok");
                break;
            case LoginResult.Fail:
                AnsiConsole.WriteLine("Wrong admin password");
                AnsiConsole.Ask<string>("Ok");
                Environment.Exit(0);
                break;
        }
    }
}