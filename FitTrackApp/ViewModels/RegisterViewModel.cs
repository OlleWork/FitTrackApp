using FitTrackApp.VMB_RC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private List<Models.User> _users; // Why is it not finding it User.cs? 

        // Initializes the RegisterNewUserCommand 
        public RegisterViewModel(List<Models.User> users)
        {
            RegisterNewUserCommand = new RelayCommand(_ => RegisterNewUser());
            _users = users;
        }
        

        private void RegisterNewUser() // Takes care of new user registrations. 
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
