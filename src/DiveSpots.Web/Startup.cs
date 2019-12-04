using System;
using System.Text;
using DiveSpots.Application;
using DiveSpots.Application.Core;
using DiveSpots.Drivers.SQL;
using DiveSpots.Web.Core;
using DiveSpots.Web.Core.TokenHandling;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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

            services.AddMediatR(
                typeof(ApplicationRegistration).Assembly);
            
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

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
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy(PolicyNames.RequireModerator, policy => policy.RequireRole(Rolenames.Moderator));
                options.AddPolicy(PolicyNames.RequireAdministrator,
                    policy => policy.RequireRole(Rolenames.Administrator));
                options.AddPolicy(PolicyNames.RequireModeratorOrAdmin, policy =>
                    policy.RequireRole(Rolenames.Administrator, Rolenames.Moderator));
            });
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DiveSpots API", Version = "v1" });
            });


            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddApplicationInsightsTelemetry();

            ApplicationServices.Register(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DiveSpots API V1");
                c.RoutePrefix = string.Empty;
            });
            
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

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.ConnectionString,
                    x => x.MigrationsAssembly("DiveSpots.Drivers.SQL")));
        }
    }
}