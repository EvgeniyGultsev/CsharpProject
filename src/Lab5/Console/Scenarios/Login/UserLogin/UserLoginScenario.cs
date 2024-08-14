using Contracts.Logging;
using Contracts.Logging.UserLogging;
using Models.User;
using Spectre.Console;

namespace Console.Scenarios.Login.UserLogin;

public class UserLoginScenario : IScenario
{
    private readonly IUserLoginService _userLoginService;

    public UserLoginScenario(IUserLoginService userLoginService)
    {
        _userLoginService = userLoginService;
    }

    public string Name => "Login as user";
    public async Task Run()
    {
        int userCardId = AnsiConsole.Ask<int>("Enter your card id");
        int pinCode = AnsiConsole.Ask<int>("Enter your pin code");

        LoginResult result = await _userLoginService.Login(new User.Card(userCardId, pinCode));

        string message = result switch
        {
            LoginResult.Success => "Successful user login",
            LoginResult.Fail => "User not found or wrong pin",
            _ => throw new ArgumentOutOfRangeException(),
        };

        AnsiConsole.WriteLine(message);
        return;
    }
}