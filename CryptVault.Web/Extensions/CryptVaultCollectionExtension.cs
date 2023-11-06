using CryptVault.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CryptVaultCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();

            return services;
        }
    }
}
