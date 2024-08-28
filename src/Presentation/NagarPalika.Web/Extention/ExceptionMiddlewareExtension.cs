using Microsoft.AspNetCore.Diagnostics;
using NagarPalika.Web;
using NagarPalika.Web.Models;
using System.Net;

namespace Dalorian.Web
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        Loggers.WriteLog("Exception status code =" + context.Response.StatusCode + " and message =  " + contextFeature.Error?.ToString() + " occurs at " +
                            DateTime.Now.ToString());
                        await context.Response.WriteAsync(new
                            ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error?.ToString()
                        }.ToString());
                    }
                    context.Response.Redirect("/Home/Login");
                });
            });

        }
    }
}
