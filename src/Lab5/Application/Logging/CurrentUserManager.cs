using Contracts.Logging;
using Models.User;

namespace Application.Logging;

public class CurrentUserManager : ICurrentUserManager
{
    public User? User { get; set; }
}