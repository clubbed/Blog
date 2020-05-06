using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }

        public string UserId { get; set; }
        public BlogUser User { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

    }
}
