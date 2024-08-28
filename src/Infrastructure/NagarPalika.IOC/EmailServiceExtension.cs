using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using NagarPalika.Data.OtherRepository;
using NagarPalika.Application.OtherRepository;
using NagarPalika.Domain.Helper;

namespace NagarPalika.IOC
{
    public static class EmailServiceExtension
    {
        public static void AddEmailService(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<EmailNotificationOptions>(configuration.GetSection("EmailConfigration"));            
            services.AddScoped<IEmailRepository, EmailRepository>();
        }
    }
}
