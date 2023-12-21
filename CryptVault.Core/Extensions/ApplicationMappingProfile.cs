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
            CardMaps();
            PasswordMaps();
        }

        public void CardMaps()
        {
            CreateMap<Card, CardViewModel>().ReverseMap();
        }
        public void PasswordMaps()
        {
            CreateMap<Password, AddPasswordViewModel>().ReverseMap();
            CreateMap<Password, PasswordViewModel>().ReverseMap();
            CreateMap<Password, EditPasswordViewModel>().ReverseMap();
            CreateMap<PasswordViewModel, EditPasswordViewModel>().ReverseMap();
        }
    }
}
