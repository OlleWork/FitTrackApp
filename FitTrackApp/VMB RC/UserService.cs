using FitTrackApp.Models;
using System.Collections.ObjectModel;
using System.Security.RightsManagement;

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
            Users.Add(new User
            {
                Username = "admin",
                Password = "password",
                IsAdmin = true, // This will make sure that its an admin
                Workouts = new ObservableCollection<Workout>()
            });
            // Lägg till en standardanvändare för test.
            Users.Add(new User
            {
                Username = "user",
                Password = "password",
                IsAdmin = false, // This will make its not an admin. 
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

        public ObservableCollection<Workout> GetEveryWorkout() // Gets a collection from all workouts from all users
        {
            var everyWorkout = new ObservableCollection<Workout>(); // Stores all workouts

            foreach (var user in Users) // Loop through every user
            {
                foreach (var workout in user.Workouts) // Goes through each users workouts
                {
                    everyWorkout.Add(workout); // Adds workout to the everyWorkout collection

                }
            }

            return everyWorkout; // Returns the collection of workouts
        }

        public void RemoveWorkout(Workout workoutReaper) // This will do it so admin can remove workouts from users list
        {
            foreach (var user in Users) // Loops through each user in the Users
            {
                if (user.Workouts.Contains(workoutReaper))
                    break; // Exit the loop if the workout is found. 
            }
        }


    }
}