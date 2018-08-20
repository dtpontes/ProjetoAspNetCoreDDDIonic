using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Infra.Persistence.EF.Map
{
    public class MapCanal : IEntityTypeConfiguration<Canal>
    {
        public void Configure(EntityTypeBuilder<Canal> builder)
        {
            //Tabela
            builder.ToTable("Canal");

            //ForeigKey
            builder.HasOne(x => x.Usuario).WithMany().HasForeignKey("IdUsuario");


            //Chave Primaria
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();

            builder.Property(x => x.UrlLogo).HasMaxLength(255).IsRequired();


        }
    }
}
