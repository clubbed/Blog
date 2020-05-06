using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int id)
        {
            var categoryViewModel = await _categoryService.GetCategory(id);

            return View(categoryViewModel);
        }
    }
}