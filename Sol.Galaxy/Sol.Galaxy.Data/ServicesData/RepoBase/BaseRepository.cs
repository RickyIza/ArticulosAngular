using Microsoft.EntityFrameworkCore;
using Sol.Galaxy.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Data.ServicesData.RepoBase
{
    public class BaseRepository<T> : IRepositorioBase<T> where T : class
    {
        private readonly VentasContext ventasContext;

        public BaseRepository(VentasContext ventasContext)
        {
            this.ventasContext = ventasContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await ventasContext.Set<T>().AddAsync(entity);
            await ventasContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            ventasContext.Set<T>().Remove(entity);
            await ventasContext.SaveChangesAsync();
        }


        public async Task DeleteByIdAsync(int id)
        {
            T? t = await ventasContext.Set<T>().FindAsync(id);
            ventasContext.Set<T>().Remove(t);
            await ventasContext.SaveChangesAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            T? t = await ventasContext.Set<T>().FindAsync(id);
            return t;
        }

        public async Task<List<T>> GetPagedReponseAsync(int page, int size)
        {
            return await ventasContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();

        }

        public async Task<List<T>> ListAllAsync()
        {
            return await ventasContext.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            ventasContext.Entry(entity).State = EntityState.Modified;
            await ventasContext.SaveChangesAsync();
        }
    }
}
