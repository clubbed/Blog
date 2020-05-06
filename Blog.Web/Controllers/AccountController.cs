using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Interfaces;
using Blog.Application.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Blog.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _userService;

        public AccountController(ILogger<AccountController> logger, 
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        public IActionResult Login(string returnUrl = "/")
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Login));
            }

            var result = await _userService.LoginAsync(model);

            if(result)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {

                ModelState.AddModelError("", "Email or Password Wrong!");
                return RedirectToAction(nameof(Login));
            }

        }

        public IActionResult Register(string returnUrl = "/")
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Register));
            }

            var result = await _userService.CreateAsync(model);

            return result ?
                RedirectToAction("Index", "Home")
                : RedirectToAction(nameof(Register));
        }
    }
}