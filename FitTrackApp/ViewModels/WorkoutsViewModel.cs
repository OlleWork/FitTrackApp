using FitTrack.PropChange;
using FitTrackApp.Models;
using FitTrackApp.Views;
using FitTrackApp.VMB_RC;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace FitTrackApp.ViewModels
{
    public class WorkoutsViewModel : INotifyPropertyChanged
    {
        // ObservableCollection to hold and update the user list for use in the View
        public ObservableCollection<User> Users { get; set; }

        public ObservableCollection<Workout> Workouts => UserService.Instance.CurrentUser?.Workouts; // Group of workouts for the user.

        public string DisplayUser => UserService.Instance.CurrentUser?.Username ?? "Guest Mode"; // This shows the logged in users username if not logged in, Guest Mode is displayed.

        public ICommand UserInfo { get; } // Binding the button with the viewmodel

        
        public WorkoutsViewModel() // Default Constructor
        {
            // Ingen extra kod behövs för att hämta Workouts eftersom Workouts kan nu bindas direkt
        }

        public WorkoutsViewModel(List<User> users) // A Constructor to initialize Users collection.
        {
            Users = new ObservableCollection<User>(users);

            UserInfo = new RelayCommand(_ => UserInfoDetails());
        }

        private void UserInfoDetails()
        {
            UserDetailsWindow userDetailsWindow = new UserDetailsWindow();

            userDetailsWindow.ShowDialog(); // Shows UserDetailsWindow as a dialog.
        }


        public event PropertyChangedEventHandler PropertyChanged; // Databinding support. 
        protected void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}