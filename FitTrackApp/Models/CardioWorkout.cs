namespace FitTrackApp.Models
{
    public class CardioWorkout : Workout // Inherits from Workout (abstract folder).
    {
        public int Distance { get; set; } // Counting the distance done during the session.

        public CardioWorkout(DateTime date, string type, TimeSpan duration, int distance, int CaloriesBurned, string notes)
        {
            Date = date;
            Type = type;
            Duration = duration;
            Distance = distance;
            CaloriesBurned = CalculateCaloriesBurned();
            Notes = notes;
        }

        public override int CalculateCaloriesBurned() // Used this to calculate calories burned for cardio sessions.
        {
            CaloriesBurned = (int)(Distance * Duration.TotalHours * 5); // Formula for the calculation of the calories. (Fråga om det ser bra ut imorgon, 5 calories per gram efter research online)-.
            return CaloriesBurned; // Returns answer.
        }
    }
}