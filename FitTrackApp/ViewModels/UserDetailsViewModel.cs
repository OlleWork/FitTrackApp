using FitTrackApp.Models;
using FitTrackApp.Views;
using FitTrackApp.VMB_RC;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace FitTrackApp.ViewModels
{
    public class UserDetailsViewModel : INotifyPropertyChanged
    {


        private string _newUsername; // Holds the username 
        public string NewUsername // Property to get n set the username.
        {
            get => _newUsername;
            set
            {
                _newUsername = value;
                OnPropertyChange(nameof(NewUsername));
            }
        }

        // Current Username and Country
        public string OldUsername => UserService.Instance.CurrentUser.Username;
        public string YourCountry => UserService.Instance.CurrentUser.Country;


        public ICommand SaveCommand { get; } // Saves your info and then returns to workout window
        public Action closeforWorkout { get; set; }

        public UserDetailsViewModel()
        {
            SaveCommand = new RelayCommand(_ => SavePath());

        }

        private void SavePath() // Method that will help handling saving a new username.
        {


            if (string.IsNullOrWhiteSpace(NewUsername) || NewUsername.Length < 3) // Checks if the username length is either empty or has less than 3 characters 
            {
                MessageBox.Show("Username must be at least 3 characters.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning); // Warning incase of. 
                return;
            }

            bool usernameExists = UserService.Instance.Users.Any(user => user.Username.Equals(NewUsername, StringComparison.OrdinalIgnoreCase)); // Makes sure the username isnt occupied.
            if (usernameExists)
            {
                MessageBox.Show("Username occupied. Please choose another.", "Invalid", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            UserService.Instance.CurrentUser.Username = NewUsername; // Updates all usernames 
            OnPropertyChange(nameof(OldUsername));

            MessageBox.Show("Successfully updates your username!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);


        }



        public event PropertyChangedEventHandler PropertyChanged; // Databinding support.

        protected void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}