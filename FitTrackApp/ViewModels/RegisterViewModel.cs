using FitTrackApp.Models;
using FitTrackApp.VMB_RC;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace FitTrackApp.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Workout> Workouts => UserService.Instance.CurrentUser?.Workouts;

        // Private fields in order to store inputs for the registration from the user. 
        private string _usernameinput; 

        private string _passwordInput;
        private string _confirmPasswordInput;
        private string _countryComboBox;
        private string _securityQuestion;
        private string _securityAnswer;

        public string UsernameInput // Username input with a change notification. Always up to date. Vice versa for the rest of them below
        {
            get => _usernameinput;
            set
            {
                _usernameinput = value;
                OnPropertyChanged(nameof(UsernameInput)); // Notifies view of the changes. Vice versa for the rest of them below
            }
        }

        public string PasswordInput 
        {
            get => _passwordInput;
            set
            {
                _passwordInput = value;
                OnPropertyChanged(nameof(PasswordInput));
            }
        }

        public string ConfirmPasswordInput 
        {
            get => _confirmPasswordInput;
            set
            {
                _confirmPasswordInput = value;
                OnPropertyChanged(nameof(ConfirmPasswordInput));
            }
        }

        public string CountryComboBox
        {
            get => _countryComboBox;
            set
            {
                _countryComboBox = value;
                OnPropertyChanged(nameof(CountryComboBox));
            }
        }

        public string SecurityQuestion
        {
            get => _securityQuestion;
            set
            {
                _securityQuestion = value;
                OnPropertyChanged(nameof(SecurityQuestion));
            }
        }

        public string SecurityAnswer
        {
            get => _securityAnswer;
            set
            {
                _securityAnswer = value;
                OnPropertyChanged(nameof(SecurityAnswer));
            }
        }

        // Collection of free security questions
        public ObservableCollection<string> SecurityQuestions { get; set; }

        // Property to hold the user's selected security question
        public string SelectedSecurityQuestion { get; set; }

        // Property to hold the user's answer to the selected security question

        // Action for registration command
        public ICommand RegisterNewUserCommand { get; }

        // Reference to the user list where the new user will be added after successful registration
        private List<User> _users;

        // Initializes the RegisterNewUserCommand
        public RegisterViewModel(List<Models.User> users)
        {
            RegisterNewUserCommand = new RelayCommand(_ => RegisterNewUser());
            _users = users;

            // Adding questions for the user to answer.
            SecurityQuestions = new ObservableCollection<string>
            {
            "What's the name of your first pet?",
            "What was the name of the first school you went to?",
            "What is your favorite food?",
            "What city were you born in?"
            };
        }

        private void RegisterNewUser() // Takes care of new user registrations.
        {
            if (PasswordInput != ConfirmPasswordInput)
            {
                MessageBox.Show("Passwords do not match.", "Registration Failed.", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool usernameCheck = UserService.Instance.Users.Any(user => user.Username == UsernameInput); // Bool double checks incase the username is occupied. 
            if (usernameCheck)
            {
                MessageBox.Show("Username occupied. Please choose another.", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error); // Error message incase of occupation of username. 
            }
            {
                var newUser = new User() // Creates a new user with the registration details.
                {
                    Username = UsernameInput,
                    Password = PasswordInput,
                    Country = CountryComboBox,
                    SecurityQuestion = SecurityQuestion,
                    SecurityAnswer = SecurityAnswer
                };

                UserService.Instance.Users.Add(newUser); // Adds user to the list in order to save it.

                MainWindow main = new MainWindow();
                main.Show(); // Directs you back to MainWindow.
            }
        }

        // Data binding.
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}