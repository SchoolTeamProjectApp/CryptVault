using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptVault.Data.Entities
{
    public class Card
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(3)]
        public string CCV { get; set; } = null!;
        [Required]
        [Range(1, maximum: 12)]
        public int ExpireMonth { get; set; }
        [Required]
        public int ExpireYear { get; set; }
        [Required]
        [StringLength(50)]
        public string NameOnCard { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
    }
}
