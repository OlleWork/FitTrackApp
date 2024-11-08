using FitTrackApp.ViewModels;
using FitTrackApp.VMB_RC;
using System.Windows;
using System.Windows.Controls;

namespace FitTrackApp.Views
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            var userList = UserService.Instance.Users.ToList(); // This grabs the list of users from the UserService
            var viewModel = new RegisterViewModel(userList); // Creates a viewmodel and then hands the list of users over.
            viewModel.closeRegisterWindow = this.Close; // Pass the Close method from the window
            DataContext = viewModel; // Links datacontext to the viewmodel. For databinding.
        }

        // Event handler for PasswordBox
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Check if the DataContext is of type RegisterViewModel
            if (this.DataContext is RegisterViewModel viewModel)
            {
                viewModel.PasswordInput = ((PasswordBox)sender).Password;  // Update the PasswordInput property in the ViewModel with the current password value.
            }
        }

        // Event handler for ConfirmPasswordBox
        private void ConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is RegisterViewModel viewModel)
            {
                viewModel.ConfirmPasswordInput = ((PasswordBox)sender).Password;
            }
        }
    }
}