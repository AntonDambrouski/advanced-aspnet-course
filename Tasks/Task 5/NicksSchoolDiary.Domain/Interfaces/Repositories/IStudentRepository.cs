﻿using NicksSchoolDiary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicksSchoolDiary.Domain.Interfaces.Repositories
{
    public interface IStudentRepository: IBaseRepository<Student>
    {
        Task<List<Student>> GetStudentsByClassIdAsync(int classId);
        Task<Student?> GetStudentByIdAsync(int studentId);
    }
}
