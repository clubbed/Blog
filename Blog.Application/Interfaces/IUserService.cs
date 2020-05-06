using Blog.Application.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateAsync(RegisterViewModel model);
        Task<bool> LoginAsync(LoginViewModel model);
    }
}
