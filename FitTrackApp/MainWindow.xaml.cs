using FitTrackApp.ViewModels;
using FitTrackApp.Views;
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

        private void OpenRegisterWindow(object sender, RoutedEventArgs e) // Method in order to open the register window, sender triggers event, e contains data from event. 
        {
            this.Hide(); // Hides the mainwindow during registration, while its open. 

            RegisterWindow registerWindow = new RegisterWindow(); // Creating an instance
            registerWindow.Owner = this; // Setting owner of RegWindow to be MainWindow
            registerWindow.ShowDialog(); // Keeps it on top and waits for it to close

            this.Show(); // Opens mainwindow again after closing regwindow. 
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