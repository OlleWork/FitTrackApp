using FitTrackApp.Models;
using FitTrackApp.Views;
using FitTrackApp.VMB_RC;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace FitTrackApp.ViewModels
{
    public class WorkoutDetailsViewModel : INotifyPropertyChanged 
    {
        public Workout SelectedWorkout { get; set; } // Holds the selected workout
        
        private bool _isReadOnly = true; // Makes sure you can't edit the details of workout yet
        public bool IsReadOnly 
        {
            get => _isReadOnly; // Gets the stats if its readonly
            set
            {
                _isReadOnly = value; // Sets the new readonly if its changed
                OnPropertyChanged(nameof(IsReadOnly)); // Updates it!
            }
        }

        public ICommand EditCommand { get; } //Button initiation for the edit and save
        public ICommand SaveCommand { get; }
        public Action closeAfterSave { get; set; } // Action to close the detailswindow once clicked save. 

        public WorkoutDetailsViewModel(Workout selectedWorkout) // Initializes the view model with the selected workout
        {
            SelectedWorkout = selectedWorkout; 
            EditCommand = new RelayCommand(_ => Edit());
            SaveCommand = new RelayCommand(_ => Save());
        }

        private void Edit() // Switches view to edit mode 
        {
            IsReadOnly = false;

        }

        private void Save() // Switches edit to view mode and then closes when clicked save. 
        {
            IsReadOnly = true;


            closeAfterSave?.Invoke(); 
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
