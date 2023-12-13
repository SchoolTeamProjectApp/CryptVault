using CryptVault.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CryptVault.Web.Controllers
{
    [Authorize]
    public class PasswordController : Controller
    {
        public readonly IPasswordService passwordService;

        public PasswordController(IPasswordService _passwordService)
        {
             this.passwordService = _passwordService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MyPasswords(Guid id)
        {
            var passwords = await passwordService.GetPasswordsByUserIdAsync(id);
            return View(passwords);
        }
    }
}
