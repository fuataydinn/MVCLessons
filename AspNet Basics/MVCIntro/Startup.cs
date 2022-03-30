using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCIntro
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles(); //Gelen request static dosyami

            app.UseRouting(); //degilse routing control et .. en son butun middlewareden gectikten sonra Endpoints cal�s�r.

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "CustomRouting01",
                 pattern: "anasayfa",  // dinamik olmayan bir request, sadece bu routing adresi yaz�l�nca cal�s�r, asagidaki yonlendirme yap�l�r.
                 defaults: new { controller = "Home", action = "Privacy" });


                //endpoints.MapControllerRoute(
                //    name:"CustomRouting02",
                //    pattern:"{*path}", //herhangi bir Request ne olursa olsun bu cal�sacak
                //    defaults:new {controller="Home",action="index" });

                endpoints.MapControllerRoute(
                    //pattern : parametresi, web uygulamas�na gonderilen/ac�lan request'in adresini (URL) temsil eder.
                    //S�sl� parantezler {} i�erisine yaz�lan ifadeler, URL'in alt bolumlerinin dinamik oldugunu temsil eder 
                    //Asag�daki varsay�lan URL sablonuna g�re ; 
                    // Wissen/Index/10 gibi bir Request icin
                    //WissenContoller s�n�f�nda yer alan 
                    //Index metodu(aciton) cal�sacak
                    //Ve o metoda 10 degeri id parametresine arguman olarak gonderilecek
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
