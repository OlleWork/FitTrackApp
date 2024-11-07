
using FitTrackApp.VMB_RC;
using System.ComponentModel;
using System.Windows.Input;


namespace FitTrackApp.ViewModels
{
    public class InfoWindowViewModel : INotifyPropertyChanged
    {
        public ICommand ReturnToWorkout {  get; }
        public InfoWindowViewModel()
        {
            ReturnToWorkout = new RelayCommand(_ => ReturnCommand());
        }

        private void ReturnCommand()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged; // Databinding support.

        protected void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
