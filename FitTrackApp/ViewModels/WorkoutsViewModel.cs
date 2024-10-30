using FitTrack.PropChange;
using FitTrackApp.Models;
using FitTrackApp.VMB_RC;
using System.Collections.ObjectModel;

namespace FitTrackApp.ViewModels
{
    internal class WorkoutsViewModel : ViewModelBase
    {
        // ObservableCollection to hold and update the user list for use in the View
        public ObservableCollection<User> Users { get; set; }

        public ObservableCollection<Workout> Workouts => UserService.Instance.CurrentUser?.Workouts;

        public WorkoutsViewModel()
        {
            // Ingen extra kod behövs för att hämta Workouts eftersom Workouts kan nu bindas direkt
        }

        public WorkoutsViewModel(List<User> users)
        {
            Users = new ObservableCollection<User>(users);
        }
    }
}