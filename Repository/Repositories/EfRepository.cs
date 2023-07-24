using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository;
namespace Core.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public EfRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}