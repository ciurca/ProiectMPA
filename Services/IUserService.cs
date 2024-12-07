using Microsoft.AspNetCore.Identity;

namespace ProiectMPA.Services
{
    public interface IUserService
    {
        Task<IdentityUser> GetCurrentUser();
    }
}
