using Microsoft.EntityFrameworkCore;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces.Base;
using Modelo.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Modelo.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ModeloContext _context;

        public BaseRepository(ModeloContext context)
        {
            _context = context;
        }

        public T Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();

            return obj;
        }
        public T Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
        }

        public void Remove(int id)
        {
            _context.Set<T>().Remove(Select(id));
        }

        public T Select(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IList<T> SelectAll()
        {
            return _context.Set<T>().ToList();
        }
    }
}
