using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrackApp.Models
{
    class StrengthWorkout : Workout
    {
        public int Repetitions { get; set; } // In order for the repitions to count.

        public override int CalculateCaloriesBurned() // Another override in order to calculate the calories burned. 
        {
            CaloriesBurned = Repetitions; // * 2? Or what should the formula be here, ask tmr, can only find way more specific formulas online. 
        }
    }
}
