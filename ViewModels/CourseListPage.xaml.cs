using System;
using System.Xml.Linq;
using ActivityApp4.Models;
using ActivityApp4.Services;
using Microsoft.Maui.Controls;


namespace ActivityApp4
{
    public partial class CourseListPage : ContentPage
    {
        private CourseDbContext dbContext;

        public CourseListPage()
        {
            InitializeComponent();
            dbContext = new CourseDbContext(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "courses.db3"));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            List<CourseModel> courses = dbContext.GetCourses().ToList();
            courseListView.ItemsSource = courses;
        }
    }
}
