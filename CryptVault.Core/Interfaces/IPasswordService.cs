using CryptVault.Core.Models.Password;
using CryptVault.Data.Entities;

namespace CryptVault.Core.Interfaces
{
    public interface IPasswordService
    {
        Task<List<PasswordViewModel>> GetPasswordsByUserIdAsync(Guid userId);
        Task<PasswordViewModel> GetPasswordById(Guid passwordId);
        Task<Guid> CreateAsync(AddPasswordViewModel model);
        Task<bool> ExistsById(Guid passwordId);
        Task<Guid> GetUserId(Guid passwordId);
        Task EditAsync(Guid id, EditPasswordViewModel model);
    }
}
