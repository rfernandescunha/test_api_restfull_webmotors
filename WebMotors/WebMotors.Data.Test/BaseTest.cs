using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;
using WebMotors.Infra.Data;

namespace WebMotors.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {

        }

        public class DbTest : IDisposable
        {
            private readonly string dataBaseName = $"dbApiTeste_{ Guid.NewGuid().ToString().Replace("-", string.Empty) }";
            public ServiceProvider ServiceProvider { get; set; }

            /// <summary>
            /// Cria Banco de Dados Test
            /// </summary>
            public DbTest()
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddDbContext<WMContext>(x =>
                    x.UseSqlServer($"Data Source=.\\SQLEXPRESS;Initial Catalog={dataBaseName};User ID=rfcunha;Password=1234567"), ServiceLifetime.Transient
                );

                ServiceProvider = serviceCollection.BuildServiceProvider();

                using (var context = ServiceProvider.GetService<WMContext>())
                {
                    context.Database.EnsureCreated();
                }
            }

            /// <summary>
            /// Delete o Banco de Dados Test
            /// </summary>
            public void Dispose()
            {
                using (var context = ServiceProvider.GetService<WMContext>())
                {
                    context.Database.EnsureDeleted();
                }
            }
        }
    }
}
