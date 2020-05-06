using Blog.Application.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.ViewModels.Category
{
    public class CategoryIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PostViewModel> Posts { get; set; }
    }
}
