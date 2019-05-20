using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Blazor.Services;
using Microsoft.AspNetCore.Components;
using Cloudcrate.AspNetCore.Blazor.Browser.Storage;
using PartagesWebBlazorFSCore3.Client.Services.Http;
using PartagesWebBlazorFSCore3.Client.Services.Js;

namespace PartagesWebBlazorFSCore3.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
              .AddSingleton<IUriHelper>(sp => WebAssemblyUriHelper.Instance)
              // Http services
              .AddSingleton<IHttpAuthService, HttpAuthService>()
              .AddSingleton<IHttpForumCategorieService, HttpForumCategorieService>()
              .AddSingleton<IHttpForumTopicService, HttpForumTopicService>()
              .AddSingleton<IHttpForumPostService, HttpForumPostService>()
              .AddSingleton<IHttpMessageService, HttpMessageService>()
              // Javascript Services
              .AddSingleton<IJsAlertifyService, JsAlertifyService>()
              .AddSingleton<IJsMomentService, JsMomentService>()
              // Nuget librarys
              .AddStorage();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
