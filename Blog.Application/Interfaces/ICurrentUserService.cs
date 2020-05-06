using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces
{
    public interface ICurrentUserService
    {
        Task<string> GetUserId();
    }
}
