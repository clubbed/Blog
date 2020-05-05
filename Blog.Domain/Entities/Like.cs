using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Entities
{
    public class Like
    {
        public string UserId { get; set; }
        public BlogUser User { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
