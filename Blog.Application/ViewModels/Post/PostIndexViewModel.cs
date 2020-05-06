using Blog.Application.ViewModels.Comment;
using System;
using System.Collections.Generic;

namespace Blog.Application.ViewModels.Post
{
    public class PostIndexViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public int NumComments { get; set; }
        public int NumLikes { get; set; }
        public string Category { get; set; }

        public List<CommentViewModel> Comments { get; set; }

    }
}
