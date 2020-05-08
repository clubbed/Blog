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

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage { get { return TotalPages > CurrentPage; } }
        public bool HasPreviousPage { get { return CurrentPage > 1; } }

        public List<PostViewModel> Posts { get; set; }
    }
}
