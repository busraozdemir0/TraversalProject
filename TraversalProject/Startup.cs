using BusinessLayer.Container;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using TraversalProject.Models;

namespace TraversalProject
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
            services.AddLogging(x =>
            {
                x.ClearProviders();  // mevcut sa�lay�c�lar varsa bunlar� temizle
                x.SetMinimumLevel(LogLevel.Debug);  // log i�lemi nerden ba�las�n(debugdan ba�las�n)
                x.AddDebug();

            });

            services.AddDbContext<Context>();
            services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>()
                .AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<Context>();
            services.AddControllersWithViews();

            services.AddHttpClient(); // api isteklerini kar��lamak i�in

            services.ContainerDependenciens(); // ba��ml�l�ktan kurtulmak i�in Extension metod yazd�k

            services.AddAutoMapper(typeof(Startup)); // Auto mapper eklemesi

            services.CustomValidator();

            services.AddControllersWithViews().AddFluentValidation();

            // proje seviyesinde authentication i�in
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()  // kullan�c� mutlaka authenticate olacak
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log1.txt");   // bu adrese ilgili de�erler loglanacak

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");  // hata sayfas�n� d�nd�rmesi i�in
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication(); // Bu sat�r UseAuthorization kodunun �st�nde yaz�lmal� ��nk� �nce giri� yapacak ard�ndan o kullan�c� yetkilendirilebilecek

			app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
