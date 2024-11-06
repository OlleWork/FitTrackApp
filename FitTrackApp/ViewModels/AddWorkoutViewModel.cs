using FitTrackApp.Models;
using FitTrackApp.Views;
using FitTrackApp.VMB_RC;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace FitTrackApp.ViewModels
{
    public class AddWorkoutViewModel : INotifyPropertyChanged
    {
        // A "backing field" for the Combobox
        private string _workoutTypeComboBox;

        public string WorkoutTypeComboBox // Property to idetinfy workout type 
        {
            get => _workoutTypeComboBox;
            set
            {
                if (_workoutTypeComboBox != value) // Double checks if the value has changed before updating it
                {
                    _workoutTypeComboBox = value;
                    OnPropertyChanged(nameof(WorkoutTypeComboBox)); // Notify UI of changes
                }
            }
        }

        public TimeSpan DurationInput { get; set; } // Timespan in order to see duration of the session
        
        public string NotesInput { get; set; } // Incase of notes from user

        public DateTime WorkoutDate { get; set; } = DateTime.Now; // Provides the date and default point is the date of making the workout session.
        public int CaloriesBurnedInput { get; set; } 

        public ICommand SaveWorkoutPath { get; } // Command in order to save the workout

        public Action closeforWorkoutWindow { get; set; } // Closes the window after its triggered by the save button.

        public AddWorkoutViewModel(List<User> users) // Constructor
        {
            SaveWorkoutPath = new RelayCommand(_ => SaveWorkout()); // Initializing the saveworkoutpath
        }

        private void SaveWorkout()
        {
            if (string.IsNullOrWhiteSpace(WorkoutTypeComboBox) || DurationInput == TimeSpan.Zero || CaloriesBurnedInput <= 0) // Makes sure the fiels are not invalid or empty
            {
                MessageBox.Show("Please fill in all fields", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Workout newWorkout; // Needed variable to hold instance 

            if (WorkoutTypeComboBox.Equals("Cardio", StringComparison.OrdinalIgnoreCase)) // If the workout type is cardio
            {
                newWorkout = new CardioWorkout(WorkoutDate, WorkoutTypeComboBox, DurationInput, 20, CaloriesBurnedInput, NotesInput) // Creates a new cardioworkout with more specified properties
                {
                    Date = WorkoutDate,
                    Type = WorkoutTypeComboBox,
                    Duration = DurationInput,
                    Distance = 5,
                    CaloriesBurned = CaloriesBurnedInput,
                    Notes = NotesInput
                };
            }
            else if (WorkoutTypeComboBox.Equals("Strength", StringComparison.OrdinalIgnoreCase)) // If the workout type is strength
            {
                newWorkout = new StrengthWorkout(WorkoutDate, WorkoutTypeComboBox, DurationInput, 20, NotesInput) // Creates a new strengthworkout with more specified properties
                {
                    Date = WorkoutDate,
                    Type = WorkoutTypeComboBox,
                    Duration = DurationInput,
                    Repetitions = 20,
                    CaloriesBurned = CaloriesBurnedInput,
                    Notes = NotesInput
                };
            }
            else
            {
                MessageBox.Show("Invalid Workout Type", "Error", MessageBoxButton.OK, MessageBoxImage.Error); // error incase of bug
                return;
            }

            UserService.Instance.CurrentUser.Workouts.Add(newWorkout);

            WorkoutsWindow workoutsWindow = new WorkoutsWindow();
            workoutsWindow.Show();
            closeforWorkoutWindow?.Invoke();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}