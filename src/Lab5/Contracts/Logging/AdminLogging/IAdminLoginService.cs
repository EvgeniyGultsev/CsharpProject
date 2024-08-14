namespace Contracts.Logging.AdminLogging;

public interface IAdminLoginService
{
    Task<LoginResult> Login(string password);
}