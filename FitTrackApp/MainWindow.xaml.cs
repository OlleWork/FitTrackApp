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


            var viewModel = new MainWindowViewModel(); //Declaring new var.

            viewModel.closeforWorkout = this.Close; // Calls to close for WorkoutWindow. 

            DataContext = viewModel; // Data Context links with Viewmodel.
            
            viewModel.closeforReg = this.Close; // Calls Mainwindow to close for RegWindow


        }

        private void OpenWorkoutsWindow()
        {
            WorkoutsWindow workoutsWindow = new WorkoutsWindow(); // Instance of workoutswindow

            workoutsWindow.Show(); // Shows workoutsWindow when logged in

            this.Close(); // Closes MainWindow incase it is open. 
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