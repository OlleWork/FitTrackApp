namespace FitTrackApp.Models
{
    internal class StrengthWorkout : Workout // Inherits from Workout (abstract folder).
    {
        public int Repetitions { get; set; } // In order for the repitions to count.

        public StrengthWorkout(DateTime date, string type, TimeSpan duration, int repetitions, string notes)
        {
            Date = date;
            Type = type;
            Repetitions = repetitions;
            Duration = duration;
            CaloriesBurned = CalculateCaloriesBurned();
            Notes = notes;
        }

        public override int CalculateCaloriesBurned() // Another override in order to calculate the calories burned.
        {
            CaloriesBurned = Repetitions * 2;
            return CaloriesBurned; //
        }
    }
}