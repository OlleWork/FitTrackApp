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
            DataContext = viewModel;
        }

        private void SignOutClick(object sender, EventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }
    }
}