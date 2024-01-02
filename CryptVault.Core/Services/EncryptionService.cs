using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptVault.Core.Interfaces;
using Microsoft.AspNetCore.DataProtection;

namespace CryptVault.Core.Services
{
    public class EncryptionService : IEncryptionService
    {
        private readonly IDataProtectionProvider dataProtectionProvider;

        public EncryptionService(IDataProtectionProvider _dataProtectionProvider)
        {
            dataProtectionProvider = _dataProtectionProvider;
        }

        public string Encrypt(string sensitiveData)
        {
            var protector = dataProtectionProvider.CreateProtector("PasswordProtector");
            return protector.Protect(sensitiveData);
        }
        public string Decrypt(string encryptedData)
        {
            var protector = dataProtectionProvider.CreateProtector("PasswordProtector");
            return protector.Unprotect(encryptedData);
        }

    }
}
