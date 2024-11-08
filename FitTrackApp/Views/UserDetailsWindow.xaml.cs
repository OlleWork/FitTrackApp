using FitTrackApp.ViewModels;
using System.Windows;

namespace FitTrackApp.Views
{

    public partial class UserDetailsWindow : Window
    {
        public UserDetailsWindow()
        {
            InitializeComponent();
            var viewModel = new UserDetailsViewModel();
            DataContext = viewModel;
            
        }

        private void Takemeback(object sender, EventArgs e) // This activates the button.
        {
            var workoutsWindow = new WorkoutsWindow(); // Shows WorkoutsWindow again
            workoutsWindow.Show();

            this.Close(); // Closes 
        }

        private void NewPasswordBox_Password(object sender, EventArgs e)
        {
            if (DataContext is UserDetailsViewModel viewModel)
            {
                viewModel.NewPassword = NewPasswordBox.Password;
            }
        }

        private void ConfirmNewPasswordBox_Password(object sender, EventArgs e)
        {
            if (DataContext is UserDetailsViewModel viewmodel)
            {
                viewmodel.ConfirmPassword = ConfirmPasswordBox.Password;
            }
        }
    }
}