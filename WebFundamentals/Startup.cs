using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebFundamentals.Middlewares;
using Microsoft.AspNetCore.Routing.Constraints; //Route Constraint iþlemleri için ekledik

namespace WebFundamentals
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();//MVC Projeye Dahil Oldu
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseStaticFiles();//wwwroot klasörünü eriþilebilir hale getirdik

            //app.UseCustomStaticFile(); Extension Metot kullanarak UseStaticFiles ya da benzeri iþlemleri gerçekleþtirebiliyoruz

            app.UseRouting();

            app.UseEndpoints(endpoints => //Kapsayýcý Route aþaðýda olmalý
            {
                endpoints.MapControllerRoute(
              name: "areas",
              pattern: "{area}/{controller=Home}/{action=Index}/{id?}" //Area yapýsý için genel bir endpoint oluþturduk
              );

                endpoints.MapControllerRoute(
               name: "person",
               pattern: "persons",
               defaults: new { controller = "Home", action = "Index" }
               );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}",//URL pattern oluþturuldu-->Default deðerleri verilmiþtir.Route Value yani Id parametresi nullable olarak eklendi
                    constraints: new { id = new IntRouteConstraint() } //ID deðerimiz integer deðer olmak zorunda
                );

            });
        }
    }
}
