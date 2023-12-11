using ConsultaApi.Data.Contexts;
using ConsultaApi.Domain.Entities;
using ConsultaApi.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaApi.Data.Repositories
{
    public class PacienteRepository: IPacienteRepository
    {
        public void Create(Paciente entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Paciente.Add(entity);
                dataContext.SaveChanges();
            }
        }

        public void Update(Paciente entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Entry(entity).State = EntityState.Modified;
                dataContext.SaveChanges();
            }
        }

        public void Delete(Paciente entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Paciente.Remove(entity);
                dataContext.SaveChanges();
            }
        }

        public List<Paciente> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Paciente
                    .OrderBy(c => c.Nome)
                    .ToList();
            }
        }

        public Paciente GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Paciente
                    .Where(p =>p.PacienteId == id)
                    .FirstOrDefault();
            }
        }
    }
}
