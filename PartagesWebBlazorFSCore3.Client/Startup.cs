using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using PartagesWebBlazorFSCore3.Client.Services;
using PartagesWebBlazorFSCore3.Client.Services.Http;
using Microsoft.AspNetCore.Blazor.Services;
using Microsoft.AspNetCore.Components;
using Cloudcrate.AspNetCore.Blazor.Browser.Storage;

namespace PartagesWebBlazorFSCore3.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
              .AddSingleton<IUriHelper>(sp => WebAssemblyUriHelper.Instance)
              // Services
              .AddSingleton<IAlertifyService, AlertifyService>()
              .AddSingleton<IMomentService, MomentService>()
              // Http services
              .AddSingleton<IHttpAuthService, HttpAuthService>()
              .AddSingleton<IHttpForumCategorieService, HttpForumCategorieService>()
              .AddSingleton<IHttpForumTopicService, HttpForumTopicService>()
              .AddSingleton<IHttpForumPostService, HttpForumPostService>()
              .AddStorage();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
