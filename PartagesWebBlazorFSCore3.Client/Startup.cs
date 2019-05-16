using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Blazorise;
using Blazorise.Bulma;
using Blazorise.Icons.FontAwesome;
using PartagesWebBlazorFSCore3.Shared.Dtos.Input.Auth;
using PartagesWebBlazorFSCore3.Client.Component;
using PartagesWebBlazorFSCore3.Client.Services;

namespace PartagesWebBlazorFSCore3.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
              .AddBlazorise(options =>
              {
                  options.ChangeTextOnKeyPress = true; // optional
              })
              .AddBulmaProviders()
              .AddFontAwesomeIcons()
              // .AddSingleton<ServerSideValidator>()
              .AddSingleton<UserForCheckIfAvailableDto>()
              .AddSingleton<UserForRegisterInputDto>()
              .AddSingleton<AlertifyService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app
              .UseBulmaProviders()
              .UseFontAwesomeIcons();
            app.AddComponent<App>("app");
        }
    }
}
