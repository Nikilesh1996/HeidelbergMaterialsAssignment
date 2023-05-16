
using SpaceXSearchWebApp.Common.Abstractions.Models;
using SpaceXSearchWebApp.Common.Contracts;
using SpaceXSearchWebApp.Common.Services;
using SpaceXSearchWebApp.Common.Utils;

namespace SpaceXSearchWebApp.Common.Registrations
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection,
                                                               ConfigurationManager configurationManager)
        {
            serviceCollection.AddScoped<ILaunchUtilityService, LaunchUtilityService>();
            serviceCollection.AddScoped<IApiUtils, ApiUtils>();

            // Api configuration registrations
            serviceCollection.Configure<SpaceXApiConfiguration>(
                configurationManager.GetSection("SpaceXApiConfigurationSettings"));

            return serviceCollection;
        }
    }
}
