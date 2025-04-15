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
    internal class StudentRepository: BaseRepository<Student>, IStudentRepository
    {

        public StudentRepository(NicksSchoolDiaryDbContext context): base(context)
        {
             
        }     
      
        public async Task<List<Student>> GetStudentsByClassIdAsync(int classId)
        {
            return  await _context.Students.Where(s => s.StudentClassId == classId).ToListAsync();
        }
        public async Task<Student?> GetStudentByIdAsync(int studentId)
        {
            return await _context.Set<Student>().FirstOrDefaultAsync(s => s.Id == studentId);
        }
    }
}
