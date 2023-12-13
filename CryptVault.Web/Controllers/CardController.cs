using CryptVault.Core.Interfaces;
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
	}
}
