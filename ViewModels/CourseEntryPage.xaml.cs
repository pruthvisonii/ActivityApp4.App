// CourseEntryPage.xaml.cs
using System;
using System.Xml.Linq;
using ActivityApp4.Models;
using ActivityApp4.Services;
using Microsoft.Maui.Controls;

namespace ActivityApp4
{
    public partial class CourseEntryPage : ContentPage
    {
        private CourseDbContext dbContext;

        public CourseEntryPage()
        {
            InitializeComponent();
            dbContext = new CourseDbContext(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "courses.db3"));
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            var course = new CourseModel
            {
                Name = txtName.Text,
                Description = txtDescription.Text
            };

            dbContext.AddCourse(course);

            Navigation.PopAsync(); // Go back to the previous page after saving.
        }
    }
}
