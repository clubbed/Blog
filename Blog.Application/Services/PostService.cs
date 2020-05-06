using Blog.Application.Interfaces;
using Blog.Application.ViewModels.Home;
using Blog.Application.ViewModels.Post;
using Blog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
    public class PostService : IPostService
    {
        private readonly BlogContext _context;

        public PostService(BlogContext context)
        {
            _context = context;
        }
        public async Task<HomeIndexViewModel> GetHomePagePosts(int page)
        {
            var posts = await _context.Posts
                .Include(c => c.User)
                .Include(c => c.Comments)
                .Include(c => c.Likes)
                .Include(c => c.Category)
                .Skip(page * 10)
                .Take(10)
                .Select(c => new PostViewModel
                {
                    Title = c.Title,
                    ShortContent = $"{c.Content.Substring(0,60)}...",
                    Username = $"{c.User.FirstName} {c.User.LastName}",
                    NumComments = c.Comments.Count,
                    NumLikes = c.Likes.Count,
                    Category = c.Category.Name,
                    Created = c.CreatedOn
                }).ToListAsync();

            return new HomeIndexViewModel { Posts = posts };
        }
    }
}
