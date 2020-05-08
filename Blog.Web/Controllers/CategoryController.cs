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

        [Route("/category/{id}")]
        public async Task<IActionResult> Index(int id, int? page)
        {
            var categoryViewModel = await _categoryService
                .GetCategory(id, page ?? 1);

            return View(categoryViewModel);
        }
    }
}