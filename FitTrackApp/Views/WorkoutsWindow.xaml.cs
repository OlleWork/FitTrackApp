using FitTrackApp.Models;
using FitTrackApp.ViewModels;
using System.Windows;

namespace FitTrackApp.Views
{
    public partial class WorkoutsWindow : Window
    {
        public WorkoutsWindow()
        {
            InitializeComponent();
            var viewModel = new WorkoutsViewModel(new List<User>());
            viewModel.closeforAdd = this.Close;
            viewModel.closeforUs = this.Close;
            viewModel.closeforDetails = this.Close;
            DataContext = viewModel;
        }

        private void SignOutClick(object sender, EventArgs e) // Signs you out from Workoutswindow
        {
            var mainWindow = new MainWindow(); // Opens up mainWindow
            mainWindow.Show();

            this.Close(); // Closes WorkoutsWindow
        }
    }
}