using CryptVault.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptVault.Core.Models.Card
{
    public class AddCardViewModel
    {
        public string Name { get; set; } = null!;
        public string CCV { get; set; } = null!;
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public string NameOnCard { get; set; } = null!;
        public Guid UserId { get; set; }
    }
}
