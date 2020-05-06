using Blog.Application.Interfaces;
using Blog.Application.ViewModels.Comment;
using Blog.Application.ViewModels.Home;
using Blog.Application.ViewModels.Post;
using Blog.Domain.Entities;
using Blog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<int> CreatePost(NewPostViewModel model)
        {
            var post = new Post
            {
                CategoryId = model.CategoryId,
                UserId = model.UserId,
                Title = model.Title,
                Content = model.Content,
                CreatedOn = DateTime.Now
            };

            await _context.Posts.AddAsync(post);

            await _context.SaveChangesAsync();

            return post.Id;
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
                    Id = c.Id,
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

        public async Task<PostIndexViewModel> GetPostById(int id)
        {
            var post = _context.Posts
               .Include(c => c.User)
               .Include(c => c.Comments)
                    .ThenInclude(x => x.User)
               .Include(c => c.Likes)
               .Include(c => c.Category)
               .FirstOrDefault(c => c.Id == id);

            var postModel = new PostIndexViewModel
            {
                Id = post.Id,
                Username = post.User.UserName,
                Category = post.Category.Name,
                Content = post.Content,
                Title = post.Title,
                Created = post.CreatedOn,
                NumLikes = post.Likes.Count,
                NumComments = post.Comments.Count,
                Comments = post.Comments.Select(c => new CommentViewModel
                {
                    //Username = $"{c.User.FirstName} {c.User.LastName}",
                    Username = c.User.Email,
                    Content = c.Content,
                    Created = c.CreatedOn,
                    PostId = c.PostId
                }).ToList()
            };

            return postModel;
        }
    }
}
