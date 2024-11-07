using FitTrackApp.Models;
using FitTrackApp.Views;
using FitTrackApp.VMB_RC;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace FitTrackApp.ViewModels
{
    public class WorkoutsViewModel : INotifyPropertyChanged
    {
        // ObservableCollection to hold and update the user list for use in the View
        public ObservableCollection<User> Users { get; set; }

        public ObservableCollection<Workout> ShowWorkouts { get; set; }
        public ObservableCollection<Workout> Workouts => UserService.Instance.CurrentUser?.Workouts; // Group of workouts for the user.
        public string DisplayUser => UserService.Instance.CurrentUser?.Username ?? "Guest Mode"; // This shows the logged in users username if not logged in, Guest Mode is displayed.

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

        public ICommand UserInfo { get; } // Binding the button with the viewmodel
        public ICommand AddWorkout { get; }
        public ICommand ViewDetails { get; }
        public ICommand RemoveCommand { get; }
        public ICommand InfoButton { get; }
        public Action closeforAdd { get; set; }
        public Action closeforUs { get; set; }

        public WorkoutsViewModel(List<User> users) // A Constructor to initialize Users collection.
        {
            Users = new ObservableCollection<User>(UserService.Instance.Users); // Initializes the Users collection from the UserService

            UserInfo = new RelayCommand(_ => UserInfoDetails());

            AddWorkout = new RelayCommand(_ => AddWOrkoutPath());

            ViewDetails = new RelayCommand(_ => OpenWorkoutDetails());

            RemoveCommand = new RelayCommand(_ => RemoveWorkout());

            InfoButton = new RelayCommand(_ => InfoPath());

            if (UserService.Instance.CurrentUser.IsAdmin) // This will determine the workouts to show based on if its a user or an admin
            {
                ShowWorkouts = UserService.Instance.GetEveryWorkout(); // If its admin it will show all workouts available from users.
            }
            else
            {
                ShowWorkouts = UserService.Instance.CurrentUser.Workouts; // If not admin it will show the workouts bound to that user.
            }
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

        private void InfoPath()
        {
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.Show();
            closeforUs?.Invoke();
        }

        private void RemoveWorkout()

        {
            if (SelectedWorkout != null) // Will make sure a workout is selected
            {
                UserService.Instance.RemoveWorkout(SelectedWorkout);
                ShowWorkouts.Remove(SelectedWorkout); // If a workout is selected it will let you remove it
                SelectedWorkout = null;
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