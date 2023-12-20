using AutoMapper;
using CryptVault.Core.Interfaces;
using CryptVault.Core.Models.Card;
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
        public async Task<bool> ExistsById(Guid passwordId)
        {
            return await repo.AllReadonly<Password>()
                             .AnyAsync(c => c.Id == passwordId);
        }

        public async Task<Guid> CreateAsync(AddCardViewModel model)
        {
            var password = autoMapper.Map<Password>(model);
            password.Id = Guid.NewGuid();
            await repo.AddAsync(password);
            await repo.SaveChangesAsync();
            return password.Id;
        }
    }
}
