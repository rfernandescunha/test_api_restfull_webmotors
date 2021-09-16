using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMotors.Infra.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<WMContext>
    {
        public WMContext CreateDbContext(string[] args)
        {
            //Usado para Criar as Migrações
            var connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=teste_webmotors;User ID=rfcunha;Password=1234567";
            var optionsBuilder = new DbContextOptionsBuilder<WMContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new WMContext(optionsBuilder.Options);
        }
    }
}
