using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicksSchoolDiary.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        ValueTask<T> AddAsync(T entity);
        ValueTask<bool> DeleteAsync(T entity);
        ValueTask<T> UpdateAsync(T entity);        
        ValueTask<List<T>> GetAllAsync();
    }
}
