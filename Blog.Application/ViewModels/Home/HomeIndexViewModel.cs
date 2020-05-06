using Blog.Application.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.ViewModels.Home
{
    public class HomeIndexViewModel
    {
        public List<PostViewModel> Posts { get; set; }
    }
}
