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
        public List<string> CountryList { get; } // Grabs the list from the AllCountries class
        
        
        private string _newPassword;
        public string NewPassword
        {
            get => _newPassword;
            set
            {
                _newPassword = value;
                OnPropertyChange(nameof(NewPassword));
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChange(nameof(ConfirmPassword));  
            }
        }

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

            NewUsername = UserService.Instance.CurrentUser.Username;

            CountryList = AllCountries.CountryNames; // Grabs the list from the AllCountries class

        }

        private void SavePath() // Method that will help handling saving a new username.
        {

            // Username
            if (!string.IsNullOrWhiteSpace(NewUsername) && NewUsername != OldUsername)
            {
                if (NewUsername.Length < 3) // Checks if the username length is either empty or has less than 3 characters 
                {
                    MessageBox.Show("Username must be at least 3 characters.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning); // Warning incase of. 
                    return;
                }

            }

            bool usernameExists = UserService.Instance.Users.Any(user => user.Username != null && user.Username.Equals(NewUsername, StringComparison.OrdinalIgnoreCase) && user != UserService.Instance.CurrentUser);
            if (usernameExists)
            {
                MessageBox.Show("Username occupied. Please choose another.", "Invalid", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            UserService.Instance.CurrentUser.Username = NewUsername;
            OnPropertyChange(nameof(OldUsername)); // Updates username


            // Password
            if (!string.IsNullOrEmpty(NewPassword) || !string.IsNullOrEmpty(ConfirmPassword))
            {
                if (NewPassword.Length < 5)
                {
                    MessageBox.Show("Password must be at least 5 characters", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning); // Lets you know, minimum 5 characters. 
                    return;
                }
            if (NewPassword != ConfirmPassword) // If it does NOT match the NewPassword
                {
                    MessageBox.Show("Passwords do not match", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                UserService.Instance.CurrentUser.Password = NewPassword; // Updates password if all matches. 
            }

            // Success!
            MessageBox.Show("Successfully updates your information!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public event PropertyChangedEventHandler PropertyChanged; // Databinding support.

        protected void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}