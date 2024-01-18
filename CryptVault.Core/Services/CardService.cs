using AutoMapper;
using CryptVault.Core.Interfaces;
using CryptVault.Core.Models.Card;
using CryptVault.Core.Models.Password;
using CryptVault.Data.Common;
using CryptVault.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptVault.Core.Services
{
	public class CardService : ICardService
	{
		private readonly IRepository repo;
		private readonly IMapper autoMapper;

		public CardService(IRepository _repo, IMapper _mapper)
		{
			this.repo = _repo;
			this.autoMapper = _mapper;
		}

		public async Task<List<CardViewModel>> GetCardsByUserIdAsync(Guid userId)
		{
			return await repo.AllReadonly<Card>()
				.Where(x => x.UserId == userId)
				.Select(x => autoMapper.Map<CardViewModel>(x))
				.ToListAsync();
		}
        public async Task<bool> ExistsById(Guid cardId)
        {
            return await repo.AllReadonly<Card>()
                             .AnyAsync(c => c.Id == cardId);
        }

        public async Task<Guid> CreateAsync(AddCardViewModel model)
        {
            var card = autoMapper.Map<Card>(model);
            card.Id = Guid.NewGuid();
            await repo.AddAsync(card);
            await repo.SaveChangesAsync();
            return card.Id;
        }



        public async Task EditAsync(Guid id, EditCardViewModel model)
        {
            if (await ExistsById(id))
            {
                var card = await repo.GetByIdAsync<Card>(id);
                card.Name = model.Name;
                card.CCV = model.CCV;
                card.ExpireMonth = model.ExpireMonth;
                card.ExpireYear = model.ExpireYear;
                card.NameOnCard = model.NameOnCard;
                await repo.SaveChangesAsync();
            }
        }

        public async Task<CardViewModel> GetCardById(Guid cardId)
        {
            return autoMapper
                .Map<CardViewModel>(
                    await repo.GetByIdAsync<Card>(cardId));
        }

        public async Task<Guid> GetUserId(Guid cardId)
        {
            if (await ExistsById(cardId))
            {
                return (await repo.GetByIdAsync<Card>(cardId)).UserId;
            }
            else
            {
                return Guid.Empty;
            }
        }
    }
}
