using AutoMapper;
using CryptVault.Core.Interfaces;
using CryptVault.Core.Models.Password;
using CryptVault.Data.Common;
using CryptVault.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        public async Task<PasswordViewModel> GetPasswordById(Guid passwordId)
        {
            return autoMapper
                .Map<PasswordViewModel>(
                    await repo.GetByIdAsync<Password>(passwordId));
        }
        public async Task<Guid> GetUserId(Guid passwordId)
        {
            if (await ExistsById(passwordId))
            {
                return (await repo.GetByIdAsync<Password>(passwordId)).UserId;
            }
            else
            {
                return Guid.Empty;
            }
        }
        public async Task<bool> ExistsById(Guid passwordId)
        {
            return await repo.AllReadonly<Password>()
                             .AnyAsync(c => c.Id == passwordId);
        }

        public async Task<Guid> CreateAsync(AddPasswordViewModel model)
        {
            var password = autoMapper.Map<Password>(model);
            password.Id = Guid.NewGuid();
            await repo.AddAsync(password);
            await repo.SaveChangesAsync();
            return password.Id;
        }

        public async Task EditAsync(Guid id, EditPasswordViewModel model)
        {
            if (await ExistsById(id))
            {
                var password = await repo.GetByIdAsync<Password>(id);
                password.Email = model.Email;
                password.Description = model.Description;
                password.Website = model.Website;
                password.Username = model.Username;
                await repo.SaveChangesAsync();
            }
        }


    }
}