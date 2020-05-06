using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Posts = new HashSet<Post>();
        }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
