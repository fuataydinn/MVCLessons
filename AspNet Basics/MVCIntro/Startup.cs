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

            app.UseRouting(); //degilse routing control et .. en son butun middlewareden gectikten sonra Endpoints calýsýr.

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "CustomRouting01",
                 pattern: "anasayfa",  // dinamik olmayan bir request, sadece bu routing adresi yazýlýnca calýsýr, asagidaki yonlendirme yapýlýr.
                 defaults: new { controller = "Home", action = "Privacy" });


                //endpoints.MapControllerRoute(
                //    name:"CustomRouting02",
                //    pattern:"{*path}", //herhangi bir Request ne olursa olsun bu calýsacak
                //    defaults:new {controller="Home",action="index" });

                endpoints.MapControllerRoute(
                    //pattern : parametresi, web uygulamasýna gonderilen/acýlan request'in adresini (URL) temsil eder.
                    //Süslü parantezler {} içerisine yazýlan ifadeler, URL'in alt bolumlerinin dinamik oldugunu temsil eder 
                    //Asagýdaki varsayýlan URL sablonuna göre ; 
                    // Wissen/Index/10 gibi bir Request icin
                    //WissenContoller sýnýfýnda yer alan 
                    //Index metodu(aciton) calýsacak
                    //Ve o metoda 10 degeri id parametresine arguman olarak gonderilecek
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
