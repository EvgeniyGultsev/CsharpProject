using System.Globalization;
using Contracts.UserActions;
using Spectre.Console;

namespace Console.Scenarios.UserOperations.ViewBalance;

public class ViewBalanceScenario : IScenario
{
    private readonly IShowMoney _showMoney;
    private readonly long _id;

    public ViewBalanceScenario(IShowMoney showMoney, long id)
    {
        _showMoney = showMoney;
        _id = id;
    }

    public string Name => "View balance";
    public async Task Run()
    {
        decimal balance = await _showMoney.ShowMoney(_id);
        AnsiConsole.WriteLine(balance.ToString(CultureInfo.InvariantCulture));

        AnsiConsole.Ask<string>("Ok");
    }
}