using AutoMapper;
using CryptVault.Core.Interfaces;
using CryptVault.Core.Models.Password;
using CryptVault.Data;
using CryptVault.Data.Common;
using CryptVault.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace CryptVault.Core.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IRepository repo;
        private readonly IMapper autoMapper;
        public PasswordService(IRepository _repo, IMapper _autoMapper)
        {
            this.repo = _repo;
            this.autoMapper = _autoMapper;
        }

        public async Task<List<PasswordViewModel>> GetPasswordsByUserIdAsync(Guid userId)
        {
            return await repo.AllReadonly<Password>()
                .Where(x => x.Id == userId)
                .Select(x => autoMapper.Map<PasswordViewModel>(x))
                .ToListAsync();
        }
    }
}