using Blog.Application.ViewModels.Home;
using Blog.Application.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces
{
    public interface IPostService
    {
        Task<HomeIndexViewModel> GetHomePagePosts(int page);
        Task<PostIndexViewModel> GetPostById(int id);

        Task<int> CreatePost(NewPostViewModel model);
    }
}
