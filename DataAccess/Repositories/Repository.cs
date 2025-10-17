using BusinessLogic.Helpers;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<IReadOnlyList<T>> GetAllAsync(
            int? pageNumber = null,
            int pageSize = 10,
            Expression<Func<T, bool>>? filtering = null,
            params string[]? includes
            )
        {
            var query = set.AsQueryable();

            if (pageNumber != null)
                query =  await query.PaginateAsync(pageNumber.Value, pageSize);

            if (filtering != null)
                query = query.Where(filtering);

            if (includes != null && includes.Length > 0)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id, params string[]? includes)
        {
            var query = set.AsQueryable();

            if (includes != null && includes.Length > 0)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }

            var item = await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
            return item;
        }

        public async Task<T?> GetByIdAsync(string id, params string[]? includes)
        {
            var query = set.AsQueryable();

            if (includes != null && includes.Length > 0)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }

            var item = await query.FirstOrDefaultAsync(e => EF.Property<string>(e, "Id") == id);
            return item;
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
            await DeleteAsync(entity);
        }

        public async Task DeleteAsync(T? entity)
        {
            if (entity != null)
            {
                set.Remove(entity);
                await context.SaveChangesAsync(true);
            }
        }
    }
}
