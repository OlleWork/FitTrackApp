using FitTrackApp.ViewModels;
using System.Windows;

namespace FitTrackApp.Views
{

    public partial class UserDetailsWindow : Window
    {
        public UserDetailsWindow()
        {
            InitializeComponent();
            DataContext = new UserDetailsViewModel();
            
        }

        private void Takemeback(object sender, EventArgs e) // This activates the button.
        {
            var workoutsWindow = new WorkoutsWindow(); // Shows WorkoutsWindow again
            workoutsWindow.Show();

            this.Close(); // Closes 
        }

        
    }
}