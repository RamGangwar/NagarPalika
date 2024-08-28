using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NagarPalika.Application.OtherRepository;
using NagarPalika.Data.OtherRepository;
using NagarPalika.Domain.Helper;

namespace NagarPalika.IOC
{
    public static class AddOtherServices
    {
       
        public static void AddGEOLocation(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<GEOLocationOptions>(configuration.GetSection("GEOLocationConfig"));
            services.AddScoped<IGeoLocationRepository, GeoLocationRepository>();
        }
    }
}
