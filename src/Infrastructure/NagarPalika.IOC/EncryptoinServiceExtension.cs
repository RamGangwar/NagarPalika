using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NagarPalika.Application.OtherRepository;
using NagarPalika.Data.OtherRepository;
using NagarPalika.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NagarPalika.IOC
{
    public static class EncryptoinServiceExtension
    {
        public static void AddEncryptionService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDataProtection();
            services.Configure<EncryptOptions>(configuration.GetSection("Encryption"));
            services.AddScoped<IEncryptRepository, EncryptRepository>();

        }
    }
}
