using FitTrackApp.Models;
using FitTrackApp.Views;
using FitTrackApp.VMB_RC;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace FitTrackApp.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Workout> Workouts => UserService.Instance.CurrentUser?.Workouts;

        // Fields connected to the username and password in the login form
        private string _username;

        private string _password;

        public string UsernameInput
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(UsernameInput));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public Action closeforWorkout { get; set; }
        public Action closeforReg { get; set; }
        // Actions for sign-in and registration. Kind of like a bridge between the UI and code.
        public ICommand SignInCommand { get; } //

        public ICommand RegisterCommand { get; }

        private User _onlineUser; // This holds information about the user that is online logged in.
        private List<User> _users; // This is a list that stores all users registered in the system.

        public MainWindowViewModel()
        {
            // This allows the UI to be clickable. Using lambda due to no parameters.
            SignInCommand = new RelayCommand(_ => SignIn());
            RegisterCommand = new RelayCommand(_ => OpenRegisterWindow());
            _users = new List<User>(); //For the userlist commented on above. And to keep data alive for the user.
        }

        private void SignIn()
        {
            _onlineUser = UserService.Instance.Users.FirstOrDefault(u =>
                u.Username == UsernameInput && u.Password == Password);

            if (_onlineUser != null)
            {
                // Opens WorkoutWindow after successful login!
                MessageBox.Show("Login Successful!", "Login", MessageBoxButton.OK);
                WorkoutsWindow workoutsWindow = new WorkoutsWindow();
                workoutsWindow.Show();
                closeforWorkout?.Invoke();
            }
            else
            {
                // This let's you know what you've written is incorrect through a prompt.
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);

                
            }
        }

        private void OpenRegisterWindow()
        {
            
            // Opens RegisterWindow
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            closeforReg?.Invoke(); // Closes the Mainwindow in order for registerwindow to open. 

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}