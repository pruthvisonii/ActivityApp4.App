using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using SQLite;
using ActivityApp4.Models;

namespace ActivityApp4.Services
{
    public class CourseDbContext : SQLiteConnection
    {
        public CourseDbContext(string databasePath) : base(databasePath)
        {
            CreateTable<CourseModel>();
        }

        public TableQuery<CourseModel> GetCourses()
        {
            return Table<CourseModel>();
        }

        public void AddCourse(CourseModel course)
        {
            Insert(course);
        }

        public void UpdateCourse(CourseModel course)
        {
            Update(course);
        }

        public void DeleteCourse(CourseModel course)
        {
            Delete(course);
        }

    }
}