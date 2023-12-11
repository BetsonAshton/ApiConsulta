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
    public class MedicoRepository: IMedicoRepository
    {
        public void Create(Medico entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Medico.Add(entity);
                dataContext.SaveChanges();
            }
        }

        public void Update(Medico entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Entry(entity).State = EntityState.Modified;
                dataContext.SaveChanges();
            }
        }

        public void Delete(Medico entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Medico.Remove(entity);
                dataContext.SaveChanges();
            }
        }

        public List<Medico> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Medico
                    .OrderBy(c => c.Nome)
                    .ToList();
            }
        }

        public Medico GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Medico
                    .Where(m => m.MedicoId == id)
                    .FirstOrDefault();
            }
        }
    }
}
