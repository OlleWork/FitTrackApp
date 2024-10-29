using FitTrackApp.Models;
using FitTrackApp.VMB_RC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FitTrackApp.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        // Registration form fields linked to properties
        public string UsernameInput { get; set; }
        public string PasswordInput { get; set; }
        public string ConfirmPasswordInput { get; set; }
        public string CountryComboBox { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }

        // Action for registration command
        public ICommand RegisterNewUserCommand { get; }

        // Reference to the user list where the new user will be added after successful registration 
        private List<User> _users; 

        // Initializes the RegisterNewUserCommand 
        public RegisterViewModel(List<Models.User> users)
        {
            RegisterNewUserCommand = new RelayCommand(_ => RegisterNewUser());
            _users = users;
        }
        

        private void RegisterNewUser() // Takes care of new user registrations. 
        {
            if (PasswordInput != ConfirmPasswordInput)
            {
                MessageBox.Show("Passwords do not match.", "Registration Failed.", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else {
                var newUser = new User() // Creates a new user with the registration details.
                {
                    Username = UsernameInput,
                    Password = PasswordInput,
                    Country = CountryComboBox,
                    SecurityQuestion = SecurityQuestion,
                    SecurityAnswer = SecurityAnswer
                };

                _users.Add(newUser); // Adds user to the list in order to save it.

                MainWindow main = new MainWindow();
                main.Show();
            }
        }
        // Data binding.
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
