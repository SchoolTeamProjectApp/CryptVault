using CryptVault.Core.Interfaces;
using CryptVault.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptVault.Core.Services
{
    public class HashingService : IHashingService
    {
        private readonly IPasswordHasher<object> dataHasher; 

        public HashingService(IPasswordHasher<object> _dataHasher)
        {
            dataHasher = _dataHasher;
        }

        public string HashData(string data)
        {
            return dataHasher.HashPassword(null, data);
        }

        public PasswordVerificationResult VerifyData(string hashedData, string providedData)
        {
            return dataHasher.VerifyHashedPassword(null, hashedData, providedData);
        }
    }
}
