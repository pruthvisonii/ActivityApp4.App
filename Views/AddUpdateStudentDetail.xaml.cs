using ActivityApp4.ViewModels;

namespace ActivityApp4.Views;

public partial class AddUpdateStudentDetail : ContentPage
{
    public AddUpdateStudentDetail(AddUpdateStudentDetailViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}