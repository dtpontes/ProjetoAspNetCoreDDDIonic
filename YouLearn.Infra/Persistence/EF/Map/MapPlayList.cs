using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Infra.Persistence.EF.Map
{
    public class MapPlayList : IEntityTypeConfiguration<PlayList>
    {
        public void Configure(EntityTypeBuilder<PlayList> builder)
        {
            //Tabela
            builder.ToTable("PlayList");

            //ForeigKey
            builder.HasOne(x => x.Usuario).WithMany().HasForeignKey("IdUsuario");


            //Chave Primaria
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();

            builder.Property(x => x.Status).IsRequired();


        }
    }
}
