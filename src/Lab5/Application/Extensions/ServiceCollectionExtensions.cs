using Application.AdminActions;
using Application.Logging;
using Application.Logging.AdminLogin;
using Application.Logging.UnLogin;
using Application.Logging.UserLogin;
using Application.UserActions;
using Contracts.AdminActions;
using Contracts.Logging;
using Contracts.Logging.AdminLogging;
using Contracts.Logging.UnLogging;
using Contracts.Logging.UserLogging;
using Contracts.UserActions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAddUser, AddUserAction>();
        collection.AddScoped<IAdminLoginService, AdminLoginService>();
        collection.AddScoped<IUnLoginService, UnLoginService>();
        collection.AddScoped<IUserLoginService, UserLoginService>();
        collection.AddScoped<IAddMoney, AddMoneyAction>();
        collection.AddScoped<IShowMoney, ShowMoneyAction>();
        collection.AddScoped<IShowOperations, ShowOperationsAction>();
        collection.AddScoped<ISubtractMoney, SubtractMoneyAction>();

        collection.AddScoped<CurrentUserManager>();
        collection.AddScoped<ICurrentUserManager>(
            p => p.GetRequiredService<CurrentUserManager>());

        return collection;
    }
}