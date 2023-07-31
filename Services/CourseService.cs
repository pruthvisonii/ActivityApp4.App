using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using SQLiteDemo.Models;

namespace SQLiteDemo.Services
{
    public class CourseService : ICourseService
    {
        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Course.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<CourseModel>();
            }
        }

        public async Task<int> AddCourse(CourseModel courseModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(courseModel);
        }

        public async Task<int> DeleteCourse(CourseModel courseModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(courseModel);
        }

        public async Task<List<CourseModel>> GetCourseList()
        {
            await SetUpDb();
            var courseList = await _dbConnection.Table<CourseModel>().ToListAsync();
            return courseList;
        }

        public async Task<int> UpdateCourse(CourseModel courseModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(courseModel);
        }
    }
}
