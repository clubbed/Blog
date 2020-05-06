using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.ViewModels.Comment
{
    public class CommentViewModel
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public string Username { get; set; }
        public DateTime Created { get; set; }
    }
}
