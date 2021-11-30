using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Mapping
{
    public class HumidityMap : IEntityTypeConfiguration<Humidity>
    {
        public void Configure(EntityTypeBuilder<Humidity> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.DataHora)
                .IsRequired()
                .HasColumnType("nvarchar(20)");

            builder.Property(w => w.UmidTemp)
              .IsRequired()
              .HasColumnType("float(5)");

            builder.Property(w => w.Umidade)
                .IsRequired()
                .HasColumnType("float(5)");

            builder.Property(w => w.UR)
                .IsRequired()
                .HasColumnType("float(5)");
           
            builder.ToTable("Humidity");
        }
    }
}
