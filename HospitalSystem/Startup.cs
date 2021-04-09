using HospitalSystem.Backend.Business;
using HospitalSystem.Backend.Business.Interfaces;
using HospitalSystem.Backend.Connection;
using HospitalSystem.Backend.Data;
using HospitalSystem.Backend.Data.Interfaces;
using HospitalSystem.Backend.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalSystem
{
    public class Startup
    {
        public Startup(
            IOptions<AppSettings> appSettings,
            IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllersWithViews();

            //services.AddSession(options =>
            //{
            //    options.Cookie.Name = ".AdventureWorks.Session";
            //    options.IdleTimeout = TimeSpan.FromSeconds(86400);
            //    options.Cookie.IsEssential = true;
            //});

            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = new PathString("/Login");
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60.0);
            });

            // Configurar objetos de configuración fuertemente tipados
            var appSettingsSection = Configuration.GetSection("AppSettings");

            services.Configure<AppSettings>(appSettingsSection);

           // services.AddCors(
           //        options => options.AddPolicy("AllowCors",
           //        builder =>
           //        {
           //            builder 
           //                .AllowAnyOrigin() 
           //                .AllowAnyMethod()
           //                .AllowAnyHeader();
           //        })
           //);

            #region "inyeccion business"
            services.AddScoped<IConnectionBase, ConnectionBase>();
            services.AddScoped<IBusinessDoctor, BusinessDoctor>();
            services.AddScoped<IBusinessUser, BusinessUser>();
            services.AddScoped<IBusinessPatient, BusinessPatient>();
            services.AddScoped<IBusinessAppointment, BusinessAppointment>();
            #endregion

            #region "inyeccion data"
            services.AddScoped<IDoctor, DataDoctor>();
            services.AddScoped<IUser, DataUser>();
            services.AddScoped<IPatient, DataPatient>();
            services.AddScoped<IAppointment, DataAppointment>();
            #endregion
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

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseSession();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                ); // allow credentials

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
