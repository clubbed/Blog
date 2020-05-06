using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.ViewModels.Post
{
    public class PostViewModel
    {
        public string Username { get; set; }
        public string Title { get; set; }
        public string ShortContent { get; set; }
        public DateTime Created { get; set; }
        public int NumComments { get; set; }
        public int NumLikes { get; set; }
        public string Category { get; set; }
    }
}
