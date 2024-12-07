using Microsoft.AspNetCore.Identity;

namespace ProiectMPA.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly HttpContext _context;
        public UserService(UserManager<IdentityUser> userManager, IHttpContextAccessor httpContext)
        {
            _userManager = userManager;
            _context = httpContext.HttpContext;
        }
        public async Task<IdentityUser> GetCurrentUser()
        {
            if (_context.User.Identity.IsAuthenticated)
            {
            return await _userManager.GetUserAsync(_context.User);
            }
            return null;
        }
    }
}
