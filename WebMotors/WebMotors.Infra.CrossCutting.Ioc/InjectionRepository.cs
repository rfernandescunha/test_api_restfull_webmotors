using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebMotors.Domain.Interfaces.IRepository;
using WebMotors.Infra.Data;
using WebMotors.Infra.Data.Repositories;

namespace WebMotors.Infra.CrossCutting.Ioc
{
    public static class InjectionRepository
    {
        public static void Register(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            serviceCollection.AddScoped<Itb_AnuncioWebmotorsRepository, tb_AnuncioWebMotorsRepository>();


            var sqlDbSettings = configuration.GetSection("SqlConfiguration");

            serviceCollection.AddDbContext<WMContext>(
                options => options.UseSqlServer(sqlDbSettings.GetSection("ConnectionString").Value)
                //options => options.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=DDD_AspNetCore;User ID=rfcunha;Password=1234567")
            );
        }
    }
}
