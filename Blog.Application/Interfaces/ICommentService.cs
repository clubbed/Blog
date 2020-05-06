using Blog.Application.ViewModels.Comment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces
{
    public interface ICommentService
    {
        Task<bool> AddComment(NewCommentViewModel model);
    }
}
