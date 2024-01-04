using CryptVault.Core.Interfaces;
using CryptVault.Core.Models.Card;
using CryptVault.Core.Models.Password;
using CryptVault.Core.Services;
using CryptVault.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CryptVault.Web.Controllers
{
	public class CardController : Controller
	{
		private readonly ICardService cardService;

		public CardController(ICardService _cardService)
		{
			this.cardService = _cardService;
		}


		[HttpGet]
		public async Task<IActionResult> MyCards(Guid id)
		{
			var cards = await cardService.GetCardsByUserIdAsync(id);
			return View(cards);
		}

		[HttpGet]
		public IActionResult AddCard() 
		{ 
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddCard(AddCardViewModel model)
		{
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                model.UserId = User.Id();
                await cardService.CreateAsync(model);
            }
            catch (Exception ms)
            {
                ModelState.AddModelError("", ms.Message);
            }

            return RedirectToAction(nameof(MyCards));
        }
	}
}
