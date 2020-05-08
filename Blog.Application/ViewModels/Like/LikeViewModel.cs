using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.ViewModels.Like
{
    public class LikeViewModel
    {
        public IEnumerable<string> UserId { get; set; }
        public IEnumerable<string> Username { get; set; }
        public int PostId { get; set; }
    }
}
