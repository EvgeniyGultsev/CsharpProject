using Models.User;

namespace Contracts.Logging;

public interface ICurrentUserManager
{
    User? User { get; }
}