using Blog.Application.ViewModels.Category;
using Blog.Application.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetCategories();
        Task<CategoryIndexViewModel> GetCategory(int categoryId);
    }
}
