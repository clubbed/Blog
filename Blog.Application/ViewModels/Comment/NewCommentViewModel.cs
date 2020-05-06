using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.ViewModels.Comment
{
    public class NewCommentViewModel
    {
        public int PostId { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
    }
}
