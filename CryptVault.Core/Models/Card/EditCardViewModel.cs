using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptVault.Core.Models.Card
{
    public class EditCardViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string CCV { get; set; } = null!;
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public string NameOnCard { get; set; } = null!;
    }
}
