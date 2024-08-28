using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace NagarPalika.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationDependencyInjection(this IServiceCollection service)
        {
            service.AddMediatR(Assembly.GetExecutingAssembly());
           // service.AddScoped<INotificationHubConnectionManger, NotificationHubConnectionManger>();
            return service;
        }
    }
}
