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
            DataContext = new WorkoutsViewModel(new List<User>());

            var viewModel = new WorkoutsViewModel(new List<User>());
            viewModel.closeforAdd = this.Close;
            DataContext = viewModel;
        }
    }
}