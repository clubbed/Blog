using Blog.Application.ViewModels.Comment;
using Blog.Application.ViewModels.Like;
using System;
using System.Collections.Generic;

namespace Blog.Application.ViewModels.Post
{
    public class PostIndexViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public int NumComments { get; set; }
        public int NumLikes { get; set; }
        public string Category { get; set; }

        public List<CommentViewModel> Comments { get; set; }
        public LikeViewModel Likes { get; set; }
    }
}
