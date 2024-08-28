using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.IOC
{
    public static class MediatRDependencyInjection
    {
        public static IServiceCollection AddMediatRDependencyInjection(this IServiceCollection service)
        {
            service.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            return service;
        }

        
    }
}
