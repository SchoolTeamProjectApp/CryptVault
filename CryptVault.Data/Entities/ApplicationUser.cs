using Microsoft.AspNetCore.Identity;

namespace CryptVault.Data.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ICollection<Card> Cards { get; set; } = new List<Card>();

        public ICollection<Password> Passwords { get; set; } = new List<Password>();
    }
}
