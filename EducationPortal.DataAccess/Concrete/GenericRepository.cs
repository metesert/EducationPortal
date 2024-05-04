using EducationPortal.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DataAccess.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        protected readonly DbContext context;
        public GenericRepository(DbContext ctx)
        {
            context = ctx;
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public void Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChangesAsync();
        }
        public async Task InsertAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
        }
        public virtual void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChangesAsync();
        }

    }
}
