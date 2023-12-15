using AutoMapper;
using CryptVault.Core.Interfaces;
using CryptVault.Core.Models.Password;
using CryptVault.Data.Common;
using CryptVault.Data.Entities;
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
                .Where(x => userId == x.UserId)
                .Select(x => autoMapper.Map<PasswordViewModel>(x))
                .ToListAsync();
        }
        public async Task<Guid> CreateAsync(AddPasswordViewModel model)
        {
            var password = autoMapper.Map<Password>(model);
            password.Id = Guid.NewGuid();
            await repo.AddAsync(password);
            await repo.SaveChangesAsync();
            return password.Id;

        }
    }
}