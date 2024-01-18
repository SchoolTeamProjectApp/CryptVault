using CryptVault.Core.Models.Card;
using CryptVault.Core.Models.Password;
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
        Task<CardViewModel> GetCardById(Guid cardId);
        public Task<bool> ExistsById(Guid passwordId);
		public Task<Guid> CreateAsync(AddCardViewModel model);
        Task<Guid> GetUserId(Guid passwordId);
        Task EditAsync(Guid id, EditCardViewModel model);
    }
}
