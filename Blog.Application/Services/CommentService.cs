using Blog.Application.Interfaces;
using Blog.Application.ViewModels.Comment;
using Blog.Domain.Entities;
using Blog.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly BlogContext _context;

        public CommentService(BlogContext context)
        {
            _context = context;
        }

        public async Task<bool> AddComment(NewCommentViewModel model)
        {
            var comment = new Comment
            {
                CreatedOn = DateTime.Now,
                Content = model.Content,
                PostId = model.PostId,
                UserId = model.UserId
            };

            await _context.Comments.AddAsync(comment);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
