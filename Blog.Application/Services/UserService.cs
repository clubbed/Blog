using Blog.Application.Interfaces;
using Blog.Application.ViewModels.Account;
using Blog.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<BlogUser> _userManager;
        private readonly SignInManager<BlogUser> _signInManager;

        public UserService(UserManager<BlogUser> userManager, 
            SignInManager<BlogUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> CreateAsync(RegisterViewModel model)
        {
            var user = new BlogUser
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            return result.Succeeded;
        }

        public async Task<bool> LoginAsync(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return false;

            await _signInManager.SignInAsync(user, true);

            return true;
        }
    }
}
