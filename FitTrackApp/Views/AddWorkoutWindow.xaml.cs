using FitTrackApp.Models;
using FitTrackApp.ViewModels;
using System.Windows;

namespace FitTrackApp.Views
{
    public partial class AddWorkoutWindow : Window
    {
        public AddWorkoutWindow()
        {
            InitializeComponent();

            var viewModel = new AddWorkoutViewModel(new List<User>());

            DataContext = viewModel;

            viewModel.closeforWorkoutWindow = this.Close;
        }
    }
}