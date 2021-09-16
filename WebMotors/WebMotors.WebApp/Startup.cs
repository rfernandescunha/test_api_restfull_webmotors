using WebMotors.Domain.Notifications;
using WebMotors.WebApp.Configurations;
using WebMotors.WebApp.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMotors.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace WebMotors.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }

        public IConfiguration configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // AutoMapper Settings
            services.AddAutoMapperConfiguration();

            // .NET Native DI Abstraction
            services.AddDependencyInjectionConfiguration(configuration);

            
            services.AddScoped<NotificationContext>();
            services.AddMvc(options => options.Filters.Add<NotificationFilter>()).SetCompatibilityVersion(CompatibilityVersion.Latest);

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //Realiza o Migration do banco de dados sem precisar executar command
            if (configuration.GetSection("SqlConfiguration").GetSection("Migration").Value.Equals("True"))
            {
                using (var service = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    using (var context = service.ServiceProvider.GetService<WMContext>())
                    {
                        context.Database.Migrate();
                    }
                }
            }
        }
    }
}
