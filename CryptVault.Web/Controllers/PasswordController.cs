using CryptVault.Core.Interfaces;
using CryptVault.Core.Models.Password;
using CryptVault.Data.Entities;
using CryptVault.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace CryptVault.Web.Controllers
{
    [Authorize]
    public class PasswordController : Controller
    {
        public readonly IPasswordService passwordService;
        public readonly UserManager<ApplicationUser> userManager;
        public PasswordController(IPasswordService _passwordService, UserManager<ApplicationUser> _userManager)
        {
            this.passwordService = _passwordService;
            this.userManager = _userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MyPasswords()
        {
            var passwords = await passwordService.GetPasswordsByUserIdAsync(User.Id());
            Console.WriteLine(passwords.Count);
            return View(passwords);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.UserId = User.Id();
                await passwordService.CreateAsync(model);
            }

            return RedirectToAction(nameof(MyPasswords));
        }

    }
}
