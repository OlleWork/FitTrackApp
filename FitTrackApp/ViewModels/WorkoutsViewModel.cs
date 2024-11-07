using FitTrackApp.Models;
using FitTrackApp.Views;
using FitTrackApp.VMB_RC;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Input;

namespace FitTrackApp.ViewModels
{
    public class WorkoutsViewModel : INotifyPropertyChanged
    {
        // ObservableCollection to hold and update the user list for use in the View
        public ObservableCollection<User> Users { get; set; }

        public ObservableCollection<Workout> Workouts => UserService.Instance.CurrentUser?.Workouts; // Group of workouts for the user.

        private Workout _selectedWorkout; // Holds the selected workout
        public Workout SelectedWorkout
        {
            get => _selectedWorkout; // Returns it
            set
            {
                if (_selectedWorkout != value) // Only update if the value is different from current. 
                {
                    _selectedWorkout = value;
                    OnPropertyChange(nameof(SelectedWorkout));
                }
            }
        }

        public string DisplayUser => UserService.Instance.CurrentUser?.Username ?? "Guest Mode"; // This shows the logged in users username if not logged in, Guest Mode is displayed.

        public ICommand UserInfo { get; } // Binding the button with the viewmodel
        public ICommand AddWorkout { get; }
        public ICommand ViewDetails { get; }
        public ICommand RemoveCommand { get; }
        public Action closeforAdd { get; set; }



        public WorkoutsViewModel(List<User> users) // A Constructor to initialize Users collection.
        {
            Users = new ObservableCollection<User>(users);

            UserInfo = new RelayCommand(_ => UserInfoDetails());

            AddWorkout = new RelayCommand(_ => AddWOrkoutPath());

            ViewDetails = new RelayCommand(_ => OpenWorkoutDetails());

            RemoveCommand = new RelayCommand(_ => RemoveWorkout());

        }

        private void AddWOrkoutPath()
        {
            AddWorkoutWindow addWorkoutWindow = new AddWorkoutWindow(); // Creates a new instance.

            addWorkoutWindow.Show();
            closeforAdd?.Invoke();
        }

        private void UserInfoDetails()
        {
            UserDetailsWindow userDetailsWindow = new UserDetailsWindow();

            userDetailsWindow.ShowDialog(); // Shows UserDetailsWindow as a dialog.
        }

        private void OpenWorkoutDetails() // Redirects to DetailsWindow
        {
            if (SelectedWorkout != null) // Checks if workout is selected
            {
                var detailsWindow = new WorkoutDetailsWindow(SelectedWorkout); // Moves you to details if selected.
                detailsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a workout.", "Selection Missing", MessageBoxButton.OK, MessageBoxImage.Information); // Lets you know that you have to select it.
            }

        }

        private void RemoveWorkout()
        {
            if (SelectedWorkout != null)
            {
                Workouts.Remove(SelectedWorkout); // If a workout is selected it will let you remove it
            }
            else
            {
                MessageBox.Show("Please select a workout before removing.", "Selection Missing", MessageBoxButton.OK, MessageBoxImage.Information); // Lets you know that you have to select it before removing.
            }
        }



        public event PropertyChangedEventHandler PropertyChanged; // Databinding support.

        protected void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}