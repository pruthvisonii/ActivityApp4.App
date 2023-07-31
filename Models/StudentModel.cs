using SQLite;

namespace SQLiteDemo.Models
{
    public class StudentModel
    {
        [PrimaryKey, AutoIncrement]
        public int StudentID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        [Ignore]
        public string FullName => $"{FirstName} {LastName}";

        // Property to represent the course assignment
        [Indexed] // Add this attribute to create an index for faster lookup
        public int AssignedCourseID { get; set; }
    }
}
