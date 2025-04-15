using Microsoft.EntityFrameworkCore;
using NicksSchoolDiary.DAL.DataContext;
using NicksSchoolDiary.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicksSchoolDiary.DAL.Repositories
{
    internal class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly NicksSchoolDiaryDbContext _context;
        public BaseRepository(NicksSchoolDiaryDbContext context)
        {
            this._context = context;
        }   

        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            var existingEntity = _context.Set<T>().Entry(entity).Entity;
            if (existingEntity == null)
            {
                return false;
            }
            _context.Set<T>().Remove(existingEntity); 
            return await _context.SaveChangesAsync() > 0;
            
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        
        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
