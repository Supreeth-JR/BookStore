using Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace E_Commerce.Middleware
{
    public static class ExceptionMiddlewareExtensions
    {
        //IApplicationBuilder.ExceptionHandling() need to add in startup.cs under Configure method to exception handler to work
        public static void ExceptionHandling(this IApplicationBuilder app) // IApplicationBuilder -- Microsoft.AspNetCore.Builder
        {
            app.UseExceptionHandler(result =>
            {
                result.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>(); //Microsoft.AspNetCore.Diagnostics

                    if (contextFeature != null)
                    {
                        var error = contextFeature.Error;

                        int LogID = new ECommerceLogger().GetLoggedID(error);

                        string strExceptionOutput = JsonConvert.SerializeObject(new response()
                        {
                            StatusCode = (int)HttpStatusCode.InternalServerError,
                            message = "LogId = " + LogID
                        });
                        response.ContentType = "application/json";
                        await context.Response.WriteAsync(strExceptionOutput);
                    }
                });
            });
        }
    }
}
