using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Mime;

namespace DFO.User.Api
{
    public static class ExceptionHandlerExtension
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (exceptionHandlerFeature != null)
                    {
                        var applicationException = exceptionHandlerFeature.Error is ApplicationException ? true : false;

                        if (applicationException)
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        else
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        context.Response.ContentType = MediaTypeNames.Application.Json;

                        var json = new
                        {
                            context.Response.StatusCode,
                            Message = applicationException ? exceptionHandlerFeature.Error.Message : exceptionHandlerFeature.Error.ToString()
                        };

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(json));
                    }
                });
            });
        }
    }
}
