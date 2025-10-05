using Microsoft.EntityFrameworkCore;
using OnionProjectSystem.Application.Interfaces.Repositories;
using OnionProjectSystem.Domain.Common;
using OnionProjectSystem.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProjectSystem.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {
        private readonly OnionProjectSystemDbContext _context;

        public WriteRepository(OnionProjectSystemDbContext context)
        {
            _context = context;
        }
        private DbSet<T> Table => _context.Set<T>();

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public async Task HardDeleteAsync(T entity)
        {
            await Task.Run(() => { Table.Remove(entity); });
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => { Table.Update(entity); });
            return entity;
        }
    }
}
