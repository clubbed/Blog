using Blog.Domain.Entities;
using Blog.Infrastructure.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Infrastructure
{
    public static class InfrastructureDependecyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlogContext>(c => 
            {
                c.UseSqlServer(configuration.GetConnectionString("BlogDb"));
            });


            services.AddIdentity<BlogUser, BlogRole>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(c =>
            {
                c.Password.RequireDigit = false;
                c.Password.RequireLowercase = false;
                c.Password.RequireNonAlphanumeric = false;
                c.Password.RequireUppercase = false;
                c.Password.RequiredLength = 6;
                c.Password.RequiredUniqueChars = 0;
            });

            services.ConfigureApplicationCookie(c =>
            {
                c.Cookie.HttpOnly = true;
                c.ExpireTimeSpan = TimeSpan.FromMinutes(10);

                c.LoginPath = "account/login";
                c.AccessDeniedPath = "account/accessdenied";
                c.SlidingExpiration = true;
            });

            services.AddAuthentication();

        }
    }
}
