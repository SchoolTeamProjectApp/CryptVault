namespace CryptVault.Core.Models.Password
{
    public class AddPasswordViewModel
    {
        public string Email { get; set; } = null!;
        public string Website { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid UserId { get; set; }
    }
}
