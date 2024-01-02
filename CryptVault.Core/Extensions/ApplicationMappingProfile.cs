using AutoMapper;
using CryptVault.Core.Interfaces;
using CryptVault.Core.Models.Card;
using CryptVault.Core.Models.Password;
using CryptVault.Core.Services;
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
            CreateMap<Password, AddPasswordViewModel>()
                //.ForMember(
                //    dest => dest.Password,
                //    opt => opt.MapFrom(src => encryptionService.Decrypt(src.EncryptedPassword)))
            .ReverseMap();
                //.ForMember(
                //    dest => dest.EncryptedPassword,
                //    opt => opt.MapFrom(src => encryptionService.Encrypt(src.Password)));

            CreateMap<Password, PasswordViewModel>().ReverseMap();
            CreateMap<Password, EditPasswordViewModel>().ReverseMap();
            CreateMap<PasswordViewModel, EditPasswordViewModel>().ReverseMap();
        }
    }
}
