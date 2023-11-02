using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptVault.Data.Entities
{
    public class Password
    {
        [Key]
        public Guid Id { get; set; }
        
        [EmailAddress]
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Website { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Username { get; set; } = null!;

        [MaxLength(200)]
        public string Description { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; } = null!;
    }
}
