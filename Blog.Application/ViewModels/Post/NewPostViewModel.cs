using Blog.Application.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.ViewModels.Post
{
    public class NewPostViewModel
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public List<CategoryViewModel> Categories { get; set; }

    }
}
