using CryptVault.Data.Common;
using CryptVault.Core.Interfaces;
using CryptVault.Core.Services;
using AutoMapper;
using CryptVault.Core.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CryptVaultCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            AutoMapperConfig(services);
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IEncryptionService, EncryptionService>();
            return services;
        }

        private static void AutoMapperConfig(IServiceCollection services)
        {
            MapperConfiguration mapperConfiguration = new(mc => 
                            mc.AddProfile(new ApplicationMappingProfile()));
            services.AddSingleton(mapperConfiguration.CreateMapper());
        }
    }
}
