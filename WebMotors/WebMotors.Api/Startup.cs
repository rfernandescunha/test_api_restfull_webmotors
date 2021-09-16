using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMotors.Api.Configurations;
using WebMotors.Infra.Data;

namespace WebMotors.Api
{
    public class Startup
    {
        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public IConfiguration configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // AutoMapper Settings
            services.AddAutoMapperConfiguration();

            // .NET Native DI Abstraction
            services.AddDependencyInjectionConfiguration(configuration);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebMotors.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebMotors.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
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
