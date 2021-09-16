using WebMotors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace WebMotors.Infra.Data.Mapping
{
    public class tb_AnuncioWebmotorsMap : IEntityTypeConfiguration<tb_AnuncioWebmotors>
    {
        public void Configure(EntityTypeBuilder<tb_AnuncioWebmotors> builder)
        {
            builder.ToTable("tb_AnuncioWebMotors");

            builder.HasKey(p => p.Id);


            builder.Property(u => u.Marca).IsRequired().HasMaxLength(45);
            builder.Property(u => u.Modelo).IsRequired().HasMaxLength(45);
            builder.Property(u => u.Versao).IsRequired().HasMaxLength(45);
            builder.Property(u => u.Ano).IsRequired();
            builder.Property(u => u.Quilometragem).IsRequired();
            builder.Property(u => u.Observacao).IsRequired();
        }
    }
}
