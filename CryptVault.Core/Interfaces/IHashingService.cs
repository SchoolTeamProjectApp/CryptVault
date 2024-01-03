using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptVault.Core.Interfaces
{
    public interface IHashingService
    {
        string HashData(string data);
        PasswordVerificationResult VerifyData(string hashedData, string providedData);

    }
}
