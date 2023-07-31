using SQLite;

namespace SQLiteDemo.Models
{
    public class CourseModel
    {
        [PrimaryKey, AutoIncrement]
        public int CourseID { get; set; }

        public string CourseName { get; set; }
    }
}
