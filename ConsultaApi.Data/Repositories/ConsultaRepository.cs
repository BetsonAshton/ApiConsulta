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
    public class ConsultaRepository: IConsultaRepository
    {
        public void Create(Consulta entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Consulta.Add(entity);
                dataContext.SaveChanges();
            }
        }

        public void Update(Consulta entity)
        {
            using (var dataContext = new DataContext())
            {
                //dataContext.Attach(entity);
                dataContext.Entry(entity).State = EntityState.Modified;
                dataContext.SaveChanges();
            }
        }

        public void Delete(Consulta entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Consulta.Remove(entity);
                dataContext.SaveChanges();
            }
        }

        public List<Consulta> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Consulta
                    .Include(c => c.Medico)
                    .Include(c => c.Paciente)
                    .OrderBy(p => p.Paciente.Nome)
                   .ThenBy(c => c.Medico.Nome)//para a segunda ordenação
                    .ToList();
            }
        }

        public Consulta GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                var consulta = dataContext.Consulta
                    .Include(c => c.Medico)
                    .Include(c => c.Paciente)
                    .Where(c => c.ConsultaId == id)
                    .FirstOrDefault();

                return consulta;
            }
        }
    }
}
