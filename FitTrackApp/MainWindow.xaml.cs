using FitTrackApp.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace FitTrackApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        // Event handler for PasswordBox
        private void PasswordInput(object sender, RoutedEventArgs e)
        {
            // Check if the DataContext is of type RegisterViewModel
            if (this.DataContext is MainWindowViewModel viewModel)
            {
                viewModel.PasswordInput = ((PasswordBox)sender).Password;  // Update the PasswordInput property in the ViewModel with the current password value.
            }
        }
    }
}