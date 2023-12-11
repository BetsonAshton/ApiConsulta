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
    public class ConsultaMap : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.ToTable("CONSULTA");

            builder.HasKey(c => c.ConsultaId);

            builder.Property(c => c.ConsultaId)
                .HasColumnName("CONSULTAID");

            builder.Property(c => c.DataConsulta)
                .HasColumnName("DATACONSULTA")
                .IsRequired();

            builder.Property(c => c.PacienteId)
                .HasColumnName("PACIENTEID")
                .IsRequired();

            builder.Property(c => c.MedicoId)
                .HasColumnName("MEDICOID")
                .IsRequired();

            // Relacionamentos
            builder.HasOne(c => c.Paciente)
                .WithMany()
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);//especifica que a exclusão de um paciente ou médico não deve resultar
                                                   //na exclusão automática de consultas associadas.

            builder.HasOne(c => c.Medico)
                .WithMany()
                .HasForeignKey(c => c.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
