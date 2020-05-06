using Blog.Application.Interfaces;
using Blog.Application.ViewModels.Category;
using Blog.Application.ViewModels.Post;
using Blog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BlogContext _context;

        public CategoryService(BlogContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryViewModel>> GetCategories()
        {
            var categories = await _context.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();

            return categories;
        }

        public async Task<CategoryIndexViewModel> GetCategory(int categoryId)
        {
            var categoryPosts = _context.Categories
                .Where(c => c.Id == categoryId)
                .Include(c => c.Posts)
                .Select(c => new CategoryIndexViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Posts = c.Posts.Select(c => new PostViewModel
                    {
                        Id = c.Id,
                        Title = c.Title,
                        ShortContent = $"{c.Content.Substring(0, 60)}...",
                        Username = $"{c.User.FirstName} {c.User.LastName}",
                        NumComments = c.Comments.Count,
                        NumLikes = c.Likes.Count,
                        Category = c.Category.Name,
                        Created = c.CreatedOn
                    }).ToList()

                }).FirstOrDefault();

            return categoryPosts;
        }
    }
}
