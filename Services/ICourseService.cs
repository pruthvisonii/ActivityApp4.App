using System.Collections.Generic;
using System.Threading.Tasks;
using SQLiteDemo.Models;

namespace SQLiteDemo.Services
{
    public interface ICourseService
    {
        Task<List<CourseModel>> GetCourseList();
        Task<int> AddCourse(CourseModel courseModel);
        Task<int> DeleteCourse(CourseModel courseModel);
        Task<int> UpdateCourse(CourseModel courseModel);
    }
}
