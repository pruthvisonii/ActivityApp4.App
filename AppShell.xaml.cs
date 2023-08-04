using ActivityApp4.Views;

namespace ActivityApp4
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddUpdateStudentDetail), typeof(AddUpdateStudentDetail));
            Routing.RegisterRoute(nameof(CourseEntryPage), typeof(CourseEntryPage));
            Routing.RegisterRoute(nameof(CourseListPage), typeof(CourseListPage));// Add this line for the new route
        }
    }
}