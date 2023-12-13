using CryptVault.Data.Entities;

namespace CryptVault.Core.Models.Password
{
    public class PasswordViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = null!;
        public string Website { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
    }
}
