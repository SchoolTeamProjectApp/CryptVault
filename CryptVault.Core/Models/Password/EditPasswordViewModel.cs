using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptVault.Core.Models.Password
{
    public class EditPasswordViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = null!;
        public string Website { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
