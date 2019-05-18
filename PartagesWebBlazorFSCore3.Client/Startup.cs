using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Blazorise;
using Blazorise.Bulma;
using Blazorise.Icons.FontAwesome;
using PartagesWebBlazorFSCore3.Shared.Dtos.Input.Auth;
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
              /*.AddBlazorise(options =>
              {
                  options.ChangeTextOnKeyPress = true; // optional
              })
              //.AddBulmaProviders()
              .AddFontAwesomeIcons()*/
              .AddSingleton<IUriHelper>(sp => WebAssemblyUriHelper.Instance)
              // Dtos
              .AddSingleton<UserForCheckIfAvailableDto>()
              .AddSingleton<UserForRegisterInputDto>()
              // Services
              .AddSingleton<IAlertifyService, AlertifyService>()
              // Http services
              .AddSingleton<IHttpAuthService, HttpAuthService>()
              .AddSingleton<IHttpForumCategorieService, HttpForumCategorieService>()
              .AddSingleton<IHttpForumTopicService, HttpForumTopicService>()
              .AddSingleton<IHttpForumPostService, HttpForumPostService>()
              .AddStorage();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            /*app
              //.UseBulmaProviders()
              .UseFontAwesomeIcons();*/
            app.AddComponent<App>("app");
        }
    }
}
