using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ActivityApp4.Models;
using ActivityApp4.Services;
using ActivityApp4.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;


namespace ActivityApp4.ViewModels

{
    public partial class StudentListPageViewModel : ObservableObject
{
    public static List<StudentModel> StudentsListForSearch { get; private set; } = new List<StudentModel>();
    public ObservableCollection<StudentModel> Students { get; set; } = new ObservableCollection<StudentModel>();

    private readonly IStudentService _studentService;

        private RelayCommand _addCourseCommand;
        public RelayCommand AddCourseCommand => _addCourseCommand ??= new RelayCommand(AddCourse);

        private RelayCommand _viewCoursesCommand;
        public RelayCommand ViewCoursesCommand => _viewCoursesCommand ??= new RelayCommand(ViewCourses);

        private async void AddCourse()
        {
            // Implement the logic to navigate to the course entry page
            await AppShell.Current.GoToAsync(nameof(CourseEntryPage));
        }

        // Method to handle the View Courses button click
        private async void ViewCourses()
        {
            // Implement the logic to navigate to the course list page
            await AppShell.Current.GoToAsync(nameof(CourseListPage));
        }
        public StudentListPageViewModel(IStudentService studentService)
    {
        _studentService = studentService;
    }



    [RelayCommand]
    public async void GetStudentList()
    {
        Students.Clear();
        var studentList = await _studentService.GetStudentList();
        if (studentList?.Count > 0)
        {
            studentList = studentList.OrderBy(f => f.FullName).ToList();
            foreach (var student in studentList)
            {
                Students.Add(student);
            }
            StudentsListForSearch.Clear();
            StudentsListForSearch.AddRange(studentList);
        }
    }


        [RelayCommand]
    public async void AddUpdateStudent()
    {
        await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail));
    }

    [RelayCommand]
    public async void EditStudent(StudentModel studentModel)
    {
        var navParam = new Dictionary<string, object>();
        navParam.Add("StudentDetail", studentModel);
        await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail), navParam);
    }

    [RelayCommand]
    public async void DeleteStudent(StudentModel studentModel)
    {
        var delResponse = await _studentService.DeleteStudent(studentModel);
        if (delResponse > 0)
        {
            GetStudentList();
        }
    }


    [RelayCommand]
    public async void DisplayAction(StudentModel studentModel)
    {
        var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
        if (response == "Edit")
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("StudentDetail", studentModel);
            await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail), navParam);
        }
        else if (response == "Delete")
        {
            var delResponse = await _studentService.DeleteStudent(studentModel);
            if (delResponse > 0)
            {
                GetStudentList();
            }
        }
    }
}
}
