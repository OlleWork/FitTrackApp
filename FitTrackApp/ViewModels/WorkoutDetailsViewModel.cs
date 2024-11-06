using FitTrackApp.Views;
using System;
using System.ComponentModel;

namespace FitTrackApp.ViewModels
{
    public class WorkoutDetailsViewModel : INotifyPropertyChanged 
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
