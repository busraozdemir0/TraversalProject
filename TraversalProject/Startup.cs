using BusinessLayer.Container;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using TraversalProject.CQRS.Handlers.DestinationHandlers;
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
            // CQRS yapýsý için
            services.AddScoped<GetAllDestinationQueryHandler>();
            services.AddScoped<GetDestinationByIDQueryHandler>();
            services.AddScoped<CreateDestinationCommandHandler>();
            services.AddScoped<RemoveDestinationCommandHandler>();
            services.AddScoped<UpdateDestinationCommandHandler>();

            // MediatR kütüphanesi ile CQRS
            services.AddMediatR(typeof(Startup));  // typeof operatörü, bir argüman olarak alýnan deðerin veri türünü bir dize olarak döndürür. Startup dosyasýyla ayný namespace'de olan dosyalar için verdiðimiz dependency injection çalýþsýn demek istiyoruz.

            services.AddLogging(x =>
            {
                x.ClearProviders();  // mevcut saðlayýcýlar varsa bunlarý temizle
                x.SetMinimumLevel(LogLevel.Debug);  // log iþlemi nerden baþlasýn(debugdan baþlasýn)
                x.AddDebug();

            });

            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>()
                .AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<Context>();

            //services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider).AddEntityFrameworkStores<Context>();

            services.AddHttpClient(); // api isteklerini karþýlamak için

            services.ContainerDependenciens(); // baðýmlýlýktan kurtulmak için Extension metod yazdýk

            services.AddAutoMapper(typeof(Startup)); // Auto mapper eklemesi

            services.CustomValidator();

            services.AddControllersWithViews().AddFluentValidation();

            // proje seviyesinde authentication için
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()  // kullanýcý mutlaka authenticate olacak
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "Resources";  // Resources adlý klasörden bilgileri çekecek
            });

            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/SignIn/";  // eðer kullanýcý sisteme giriþ yapmamýþsa buraya yönlendirsin
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log1.txt");   // bu adrese ilgili deðerler loglanacak

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

            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");  // hata sayfasýný döndürmesi için
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication(); // Bu satýr UseAuthorization kodunun üstünde yazýlmalý çünkü önce giriþ yapacak ardýndan o kullanýcý yetkilendirilebilecek

			app.UseRouting();

            app.UseAuthorization();

            var supportedCultures = new[] { "en", "fr", "es", "gr", "tr", "de" };  // desteklenen diller
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[1]).AddSupportedCultures(supportedCultures).AddSupportedUICultures(supportedCultures); // dillerin görünüm sayfasýna eklenmesi
            app.UseRequestLocalization(localizationOptions);

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
        }
    }
}
