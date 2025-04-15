using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NicksSchoolDiary.DAL.DataContext;
using NicksSchoolDiary.DAL.Repositories;
using NicksSchoolDiary.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicksSchoolDiary.DAL.Registrators
{
    public static class DALRegistrator
    {
        public static void RegisterService(IServiceCollection services, IConfiguration configuration, bool isDevelopment) 
        {
            if (isDevelopment)
            {
                services.AddDbContext<NicksSchoolDiaryDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                );
            }
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentClassRepository, StudentClassRepository>();
        }
    }
}
