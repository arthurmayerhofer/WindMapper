using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Mapping
{
    public class WindMap : IEntityTypeConfiguration<Wind>
    {
        public void Configure(EntityTypeBuilder<Wind> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.DataHora)
                .IsRequired()
                .HasColumnType("nvarchar(20)");

            builder.Property(w => w.Direcao)
                .IsRequired()
                .HasColumnType("float(10)");

            builder.Property(w => w.Velocidade)
                .IsRequired()
                .HasColumnType("float(10)");
           
            builder.ToTable("Wind");
        }
    }
}
