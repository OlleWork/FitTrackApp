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
                Username = "admin",
                Password = "password",
                Workouts = new ObservableCollection<Workout>
                    {
                    new CardioWorkout(DateTime.Now, "Cardio", TimeSpan.FromMinutes(30), 100, 30, ""),
                    new StrengthWorkout(DateTime.Now, "Strength", TimeSpan.FromMinutes(20), 30, "")
                    }
            });

            Users.Add(new User
            {
                Username = "user",
                Password = "password",
                Workouts = new ObservableCollection<Workout>
                    {
                    new CardioWorkout(DateTime.Now, "Cardio", TimeSpan.FromMinutes(50), 140, 40, ""),
                    new StrengthWorkout(DateTime.Now, "Strength", TimeSpan.FromMinutes(50), 60, "")
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