using JuntoSeguros.Models.ConfigurationSettings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JuntoSeguros.Models.Data
{
    public class Repository<T> : IRepository<T> where T : Entidade
    {
        private readonly ConfigureModelsDbContext _context;

        public Repository(ConfigureModelsDbContext ctx)
        {
            _context = ctx;
        }

        //methods
        public T Add(T model)
        {
            _context.Entry(model).State = EntityState.Added;
            _context.SaveChanges();

            return model;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T model)
        {
            var ent = _context.Set<T>().Find(model.Id);

            if (ent != null)
            {
                var local = _context.Set<T>().Local.Where(x => x.Id == model.Id).FirstOrDefault();
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                    _context.Remove(model);
                }
            }
            else
                throw new Exception(string.Format("Id of {0} not exists.", typeof(T).Name));

            _context.SaveChanges();
        }

        public void Update(T model)
        {
            var ent = _context.Set<T>().Find(model.Id);

            if (ent != null)
            {
                var local = _context.Set<T>().Local.Where(x => x.Id == model.Id).FirstOrDefault();
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                    _context.Update(model);
                }
            }

            else
                throw new Exception(string.Format("Id of {0} not exists.", typeof(T).Name)); //_context.Entry(model).State = EntityState.Added;

            _context.SaveChanges();
        }
    }
}
