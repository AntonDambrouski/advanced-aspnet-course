using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicksSchoolDiary.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<T> UpdateAsync(T entity);        
        Task<List<T>> GetAllAsync();
    }
}
