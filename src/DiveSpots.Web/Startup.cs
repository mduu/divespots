using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiveSpots.Drivers.SQL;
using DiveSpots.Web.Core.TokenHandling;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace DiveSpots.Web
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
            ConfigureDatabase(services);
            
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<SpotsDbContext>()
                .AddDefaultTokenProviders();

            services
                .AddDefaultIdentity<IdentityUser>(options =>
                    options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<SpotsDbContext>();
            
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddJwtBearer("JwtBearer", jwtBearerOptions =>
                {                        
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                    {                            
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration[nameof(TokenConfiguration.TokenSecurityKey)])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true, //validate the expiration and not before values in the token
                        ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                    };
                });

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddApplicationInsightsTelemetry();

            ApplicationServices.Register(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
        
        private void ConfigureDatabase(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var builder = new SqlConnectionStringBuilder(connectionString);

            if (!string.IsNullOrWhiteSpace(Configuration["DbUser"]))
            {
                builder.UserID = Configuration["DbUser"];
            }

            if (!string.IsNullOrWhiteSpace(Configuration["DbPassword"]))
            {
                builder.Password = Configuration["DbPassword"];
            }

            services.AddDbContext<SpotsDbContext>(options =>
                options.UseSqlServer(
                    builder.ConnectionString,
                    x => x.MigrationsAssembly("DiveSpots.Drivers.SQL")));
        }
    }
}