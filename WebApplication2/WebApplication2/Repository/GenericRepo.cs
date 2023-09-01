using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class GenericRepo<T> : IGeneric<T> where T : class
    {
        private readonly MiniprojectContext _context;
        private readonly DbSet<T> _dbset;

        public GenericRepo(MiniprojectContext context) { 
            _context =  context;
            _dbset = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _dbset.ToList();
        }
   
        public async Task<T> Add(T entity)
        {
           await _dbset.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbset.Remove(entity);
            await _context.SaveChangesAsync();
        }


        public async Task<T> GetById(int id)
        {
            var x = await _dbset.FindAsync(id);
            return x;
        }

        public async Task<T> Update( T entity)
        {
            _dbset.Update(entity);
            await _context.SaveChangesAsync();
            return entity;

        }
    }
}
