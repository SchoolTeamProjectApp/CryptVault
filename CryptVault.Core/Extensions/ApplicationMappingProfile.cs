using AutoMapper;
using CryptVault.Core.Models.Card;
using CryptVault.Core.Models.Password;
using CryptVault.Data.Entities;

namespace CryptVault.Core.Extensions
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Password, PasswordViewModel>();
            CreateMap<Card, CardViewModel>();
        }
    }
}
