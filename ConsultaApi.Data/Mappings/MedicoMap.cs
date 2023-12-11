using ConsultaApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaApi.Data.Mappings
{
    public class MedicoMap : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("MEDICO");

            builder.HasKey(m => m.MedicoId);

            builder.Property(m => m.MedicoId)
               .HasColumnName("MEDICOID");

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Especialidade)
               .HasColumnName("ESPECIALIDADE")
               .HasMaxLength(50)
               .IsRequired();


        }
    }
}
