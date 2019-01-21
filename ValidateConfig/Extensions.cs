using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ValidateConfig.Exceptions;
using ValidateConfig.Filters;

namespace ValidateConfig
{
    public static class Extensions
    {
        public static IServiceCollection RegisterConfig<TConfig>(this IServiceCollection services, IConfiguration configuration, string sectionName) where TConfig : class, IValidateConfig, new()
        {
            if (configuration == null)
            {
                throw new InvalidConfigurationException(typeof(TConfig), "The configuration object is null");
            }

            if (string.IsNullOrWhiteSpace(sectionName))
            {
                throw new InvalidConfigurationException(typeof(TConfig), "Provide a name of the section to read from the appconfig.json");
            }

            services.Configure<TConfig>(configuration.GetSection(sectionName));
            services.AddSingleton(provider => provider.GetRequiredService<IOptions<TConfig>>().Value);
            services.AddSingleton<IValidateConfig>(provider => provider.GetRequiredService<IOptions<TConfig>>().Value);

            return services;
        }

        public static void ValidateConfigs(this IServiceCollection services)
        {
            services.AddTransient<IStartupFilter, ValidateConfigurationFilter>();
        }
    }
}