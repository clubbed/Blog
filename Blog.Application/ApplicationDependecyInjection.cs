using Blog.Application.Interfaces;
using Blog.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Application
{
    public static class ApplicationDependecyInjection
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
