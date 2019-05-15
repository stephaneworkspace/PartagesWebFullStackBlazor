using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Blazorise;
using Blazorise.Bulma;
using Blazorise.Icons.FontAwesome;

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
              .AddFontAwesomeIcons();
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
