using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrackApp.Models
{
    public abstract class Workout
    {
        public string? Notes {  get; set; } // Notes about the workout
        public TimeSpan Duration { get; set; } // Duration of the workout in detail (Hours, minutes, seconds)
        public DateTime Date { get; set; } = DateTime.Now; // The date and the time
        public int CaloriesBurned { get; set; } // How many calories burned.
        public string? Type { get; set; } // Type of workout, either cardio or strength. 

        public abstract int CalculateCaloriesBurned(); // Declaring this abstract method to use for StrengthWorkout.cs and CardioWorkout.cs 
    }
}
