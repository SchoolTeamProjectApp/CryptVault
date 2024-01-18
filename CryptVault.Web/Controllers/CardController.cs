using AutoMapper;
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
        public readonly IMapper autoMapper;

        public CardController(ICardService _cardService, IMapper _autoMapper)
		{
			this.cardService = _cardService;
            autoMapper = _autoMapper;
		}


		[HttpGet]
		public async Task<IActionResult> MyCards()
		{
			List<CardViewModel> cards = await cardService.GetCardsByUserIdAsync(User.Id());
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
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (!(await cardService.ExistsById(id)))
            {
                ModelState.AddModelError("", "Card doesn't exist!");
                //return RedirectToAction(nameof(MyCards));
            }

            if (User.Id() != await cardService.GetUserId(id))
            {
                ModelState.AddModelError("", "Access denied! You cannot access another users cards!");
                //return RedirectToAction(nameof(MyCards));
            }

            var cardModel = autoMapper.Map<EditCardViewModel>(await cardService.GetCardById(id));
            return View(cardModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, EditCardViewModel model)
        {
            if (!(await cardService.ExistsById(id)))
            {
                ModelState.AddModelError("", "Card does not exist!");
                return View(model);
            }

            if (await cardService.GetUserId(id) != User.Id())
            {
                ModelState.AddModelError("", "Cannot edit another users cards");
                return View(model);
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await cardService.EditAsync(id, model);

            return RedirectToAction(nameof(MyCards));
        }
    }
}
