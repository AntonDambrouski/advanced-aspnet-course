using Microsoft.EntityFrameworkCore;
using NicksSchoolDiary.DAL.DataContext;
using NicksSchoolDiary.Domain.Interfaces.Repositories;
using NicksSchoolDiary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicksSchoolDiary.DAL.Repositories
{
    internal class StudentClassRepository: BaseRepository<StudentClass>, IStudentClassRepository
    {
        public StudentClassRepository(NicksSchoolDiaryDbContext context) : base(context)
        {
        }

        public async Task<StudentClass?> GetStudentClassAsync(int id)
        {
            return await _context.Set<StudentClass>().FirstOrDefaultAsync(x => x.Id == id);
        }
    }  
}
