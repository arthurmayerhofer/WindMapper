using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Mapping
{
    public class StationMap : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.HasKey(w => w.Id);
           
            builder.HasOne(w => w.Vento);
            builder.HasOne(w => w.Umidade);

            builder.Property(w => w.Nome)
                .IsRequired()
                .HasColumnType("nvarchar(10)");

            builder.Property(w => w.Local)
                .IsRequired()
                .HasColumnType("nvarchar(10)");

            builder.Property(w => w.Temperatura)
               .IsRequired()
               .HasColumnType("float(5)");

            builder.ToTable("Station");
        }
    }
}
