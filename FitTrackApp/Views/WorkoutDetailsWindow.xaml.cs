using FitTrackApp.Models;
using FitTrackApp.ViewModels;
using System.Windows;


namespace FitTrackApp.Views
{

    public partial class WorkoutDetailsWindow : Window
    {

        public WorkoutDetailsWindow(Workout selectedWorkout)
        {
            InitializeComponent();


            var viewModel = new WorkoutDetailsViewModel(selectedWorkout);
            viewModel.closeAfterSave = this.Close;
            DataContext = viewModel;
        }
    }
}

