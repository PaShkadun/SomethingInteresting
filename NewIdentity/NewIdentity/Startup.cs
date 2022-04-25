using IdentityServer4;
using IdentityServer4.Services;
using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NewIdentity.Context;
using NewIdentity.Models;
using System.Reflection;

namespace NewIdentity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<AuthContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            System.Console.WriteLine(Configuration.GetConnectionString("DefaultConnection"));

            //services.AddIdentity<AuthUser, IdentityRole>().AddEntityFrameworkStores<AuthContext>().AddDefaultTokenProviders();*/

            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddIdentity<AuthUser, IdentityRole>()
                    .AddEntityFrameworkStores<AuthContext>()
                    .AddDefaultTokenProviders();

            var builder = services.AddIdentityServer()
                                  .AddInMemoryApiResources(Config.GetApiResources())
                                  .AddInMemoryIdentityResources(Config.GetIdentityResources())
                                  .AddInMemoryApiScopes(Config.GetApiScopes())
                                  .AddInMemoryClients(Config.Clients);

            builder.AddDeveloperSigningCredential();

            services.AddCors(options =>
            {
                options.AddPolicy("VuePolicy", policy =>
                {
                    policy.WithOrigins("http://localhost:8080").AllowAnyHeader().AllowAnyMethod();
                });
            });

            var logger = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseCors("VuePolicy");

            //DbInitializator.InitializeDatabase(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
