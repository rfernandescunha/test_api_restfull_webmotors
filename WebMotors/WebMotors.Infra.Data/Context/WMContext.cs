
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using WebMotors.Domain.Entities;
using WebMotors.Infra.Data.Mapping;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;

namespace WebMotors.Infra.Data
{
    public partial class WMContext : DbContext
    {
        public DbSet<tb_AnuncioWebmotors> tb_AnuncioWebmotors { get; set; }

        public WMContext(DbContextOptions<WMContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<tb_AnuncioWebmotors>(new tb_AnuncioWebmotorsMap().Configure);


        }
    }
}