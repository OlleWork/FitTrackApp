using FitTrackApp.Models;
using FitTrackApp.ViewModels;
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
            DataContext = new RegisterViewModel(new List<User>());
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