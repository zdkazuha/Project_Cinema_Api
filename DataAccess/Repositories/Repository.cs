using BusinessLogic.Helpers;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, BaseEntity
    {
        internal CinemaDbContext context;
        internal DbSet<T> set;

        public Repository(CinemaDbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(int? pageNumber = null, int pageSize = 10)
        {
            var query = set.AsQueryable();

            if (pageNumber != null)
                return await PagedList<T>.CreateAsync(query, pageNumber.Value, pageSize);

            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await set.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await set.AddAsync(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                set.Remove(entity);
                await context.SaveChangesAsync(true);
            }
        }
    }
}
