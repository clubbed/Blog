using Blog.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public async Task<string> GetUserId()
        {
            return _contextAccessor.HttpContext.User?.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
