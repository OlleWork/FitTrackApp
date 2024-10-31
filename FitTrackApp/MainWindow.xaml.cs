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

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Check if the DataContext is of type MainViewModel
            if (this.DataContext is MainWindowViewModel viewModel)
            {
                // Update the PasswordInput property in the ViewModel with the current password value
                viewModel.Password = ((PasswordBox)sender).Password;
            }
        }
    }
}