using Microsoft.AspNetCore.Blazor.Hosting;

namespace PartagesWebBlazorFSCore3.Client
{
    static class Constants
    {
        public const string URL_BASE = "http://localhost:54789/";
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
            BlazorWebAssemblyHost.CreateDefaultBuilder()
                .UseBlazorStartup<Startup>();
    }
}
