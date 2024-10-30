using FitTrack.PropChange;
using FitTrackApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitTrackApp.VMB_RC;


namespace FitTrackApp.ViewModels  
{
    class WorkoutsViewModel : ViewModelBase
    {
        public ObservableCollection<Workout> Workouts => UserService.Instance.CurrentUser?.Workouts;
        public WorkoutsViewModel()
        {
            // Ingen extra kod behövs för att hämta Workouts eftersom Workouts kan nu bindas direkt
          
        }
    }
}

