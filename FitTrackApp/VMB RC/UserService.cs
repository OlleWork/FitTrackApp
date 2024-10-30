using FitTrackApp.Models;
using System.Collections.ObjectModel;

namespace FitTrackApp.VMB_RC
{
    public class UserService
    {
        private static UserService _instance;
        public static UserService Instance => _instance ??= new UserService();

        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();
        public User CurrentUser { get; set; }

        private UserService()
        {
            // Lägg till en standardanvändare för test.
            Users.Add(new User
            {
                Username = "1",
                Password = "1",
                Workouts = new ObservableCollection<Workout>
                    {
                    new CardioWorkout(DateTime.Now, "Cardio", 90),
                    new StrengthWorkout(DateTime.Now, "Strength", 50)
                    }
            });
        }

        public bool Login(string username, string password)
        {
            foreach (var user in Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    CurrentUser = user;
                    return true;
                }
            }
            return false;
        }
    }
}