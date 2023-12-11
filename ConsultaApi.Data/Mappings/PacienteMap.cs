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
    public class PacienteMap : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("PACIENTE");

            builder.HasKey(p => p.PacienteId );

            builder.Property(p => p.PacienteId)
               .HasColumnName("PACIENTEID");

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.DataNascimento)
               .HasColumnName("DATANASCIMENTO")
               .IsRequired();



        }
    }
}
