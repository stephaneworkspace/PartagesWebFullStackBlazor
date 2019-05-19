using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
// https://github.com/aspnet/AspNetCore/issues/5223
// not for udemy
namespace PartagesWebBlazorFSCore3.Server.Helpers
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger Logger;
        public ExceptionHandlerMiddleware(ILogger logger)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (ex == null)
                return;

            Logger.LogError(new EventId(500, "InternalServerError"), ex, ex.Message);

            context.Response.ContentType = "text/html";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            using (var writter = new StreamWriter(context.Response.Body))
            {
                await writter.WriteLineAsync("<html>");
                await writter.WriteLineAsync("<body>");
                await writter.WriteLineAsync("<p>Invalid request.</p>");
#if (DEBUG)
                await writter.WriteLineAsync($"<p>{ex.InnerException?.Message ?? ex.Message}</p>");
#endif
                await writter.WriteLineAsync("</body>");
                await writter.WriteLineAsync("</html>");
                await writter.FlushAsync();
            }
        }
    }
}
