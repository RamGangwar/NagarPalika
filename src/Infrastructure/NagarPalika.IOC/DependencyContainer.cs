using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NagarPalika.Application.OtherRepository;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Data.OtherRepository;
using NagarPalika.Data.Repository;
using NagarPalika.Data.UnitOfWork;
using NagarPalika.Domain.Helper;

namespace NagarPalika.IOC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddServiceDependency( this IServiceCollection services, WebApplicationBuilder builder)
         {

            services.AddScoped<IUnitofWork, UnitofWork>();
            services.AddScoped<IBaseUnitOfWork, BaseUnitOfWork>();
            #region Repositories 
            services.AddHttpContextAccessor();
            services.AddSingleton<IEmployeeProvider, EmployeeProvider>();
            services.Configure<DomainServiceOptions>(builder.Configuration.GetSection("Domain"));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IRefreshTokensRepository, RefreshTokensRepository>();
           
            services.AddScoped<ICommonMethod, CommonMethod>();
            services.AddScoped<IJWTService, JWTService>();
            #endregion

            return services;
        }

    }
}
