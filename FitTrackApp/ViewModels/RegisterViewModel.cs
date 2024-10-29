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
        public string UsernameInput { get; set; }
        public string PasswordInput { get; set; }
        public string ConfirmPasswordInput { get; set; }
        public string CountryComboBox { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }

        public ICommand RegisterNewUserCommand { get; }

        private List<Models.User> _users; // Why is it not finding it User.cs? 

        public RegisterViewModel(List<Models.User> users)
        {
           
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
