using CryptVault.Core.Models.Password;

namespace CryptVault.Core.Interfaces
{
    public interface IPasswordService
    {
        Task<List<PasswordViewModel>> GetPasswordsByUserIdAsync(Guid userId);
    }
}
