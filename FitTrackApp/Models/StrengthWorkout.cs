namespace FitTrackApp.Models
{
    internal class StrengthWorkout : Workout // Inherits from Workout (abstract folder).
    {
        public int Repetitions { get; set; } // In order for the repitions to count.

        public override int CalculateCaloriesBurned() // Another override in order to calculate the calories burned.
        {
            CaloriesBurned = Repetitions * 2;
            return CaloriesBurned; //
        }
        public StrengthWorkout(DateTime date, string type, int repetitions)
        {
            Date = date;
            Type = type;
            Repetitions = repetitions;
        }
    }
}