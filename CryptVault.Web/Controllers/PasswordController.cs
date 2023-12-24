using AutoMapper;
using CryptVault.Core.Interfaces;
using CryptVault.Core.Models.Password;
using CryptVault.Data.Entities;
using CryptVault.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CryptVault.Web.Controllers
{
    [Authorize]
    public class PasswordController : Controller
    {
        public readonly IPasswordService passwordService;
        public readonly UserManager<ApplicationUser> userManager;
        public readonly IMapper autoMapper;
        public PasswordController(IPasswordService _passwordService, UserManager<ApplicationUser> _userManager, IMapper autoMapper)
        {
            this.passwordService = _passwordService;
            this.userManager = _userManager;
            this.autoMapper = autoMapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MyPasswords()
        {
            var passwords = await passwordService.GetPasswordsByUserIdAsync(User.Id());
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                model.UserId = User.Id();
                await passwordService.CreateAsync(model);
            }
            catch (Exception ms)
            {
                ModelState.AddModelError("", ms.Message);
            }

            return RedirectToAction(nameof(MyPasswords));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (!(await passwordService.ExistsById(id)))
            {
                ModelState.AddModelError("", "Password doesn't exist!");
                return RedirectToAction(nameof(MyPasswords));
            }

            if (User.Id() != await passwordService.GetUserId(id))
            {
                ModelState.AddModelError("", "Access denied! You cannot access another users password!");
                return RedirectToAction(nameof(MyPasswords));
            }
            
            var pwdModel = autoMapper.Map<EditPasswordViewModel>(await passwordService.GetPasswordById(id));
            return View(pwdModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, EditPasswordViewModel model)
        {
            if (!(await passwordService.ExistsById(id)))
            {
                ModelState.AddModelError("", "Password does not exist!");
                return View(model);
            }
            
            if (await passwordService.GetUserId(id) != User.Id())
            {
                ModelState.AddModelError("", "Cannot edit another users password");
                return View(model);
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await passwordService.EditAsync(id, model);

            return RedirectToAction(nameof(MyPasswords));
        }

    }
}
