//-----------------------------------------------------------------------
// <license>GPL 2</license>
// <author>Stéphane</author>
//-----------------------------------------------------------------------
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using PartagesWebBlazorFSCore3.Server.Data;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PartagesWebBlazorFSCore3.Server.Helpers;
using Microsoft.Extensions.Logging;

namespace PartagesWebBlazorFSCore3.Server
{
    public class Startup
    {
        /// <summary>  
        /// Variable for configuration
        /// </summary> 
        public IConfiguration Configuration { get; }
        /// <summary>  
        /// Constructor
        /// </summary> 
        /// <param name="configuration">Configuration</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Method called by the runtime
        /// </summary>
        /// <param name="services">Services</param>
        /// <remarks>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// </remarks>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x => x.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().AddNewtonsoftJson();
            services.AddSwaggerDocument();
            // services.AddCors();
            services.AddAutoMapper();
            services.AddTransient<Seed>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IForumRepository, ForumRepository>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                            .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
        }
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app">Application Builder</param>
        /// <param name="env">Host Environment</param>
        /// <remarks>This method gets called by the runtime. Use this method to configure the HTTP request pipeline.</remarks>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Seed seeder, ILoggerFactory loggerFactory)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
                /*
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    ExceptionHandler = new ExceptionHandlerMiddleware(loggerFactory.CreateLogger("SystemErrors")).Invoke
                });*/
            }

            app.UseRouting();

            // cut
            // seeder.SeedUsers(); Data already Seed in Database
            // seeder.SeedForumCategorie();
            // seeder.SeedForumTopic();
            // seeder.SeedForumPost();
            // app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUi3();
            // cut

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            app.UseBlazor<Client.Startup>();
        }
    }
}
