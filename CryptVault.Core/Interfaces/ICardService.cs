using CryptVault.Core.Models.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptVault.Core.Interfaces
{
	public interface ICardService
	{
		public Task<List<CardViewModel>> GetCardsByUserIdAsync(Guid userId);
		public Task<bool> ExistsById(Guid passwordId);

		public Task<Guid> CreateAsync(AddCardViewModel model);
    }
}
