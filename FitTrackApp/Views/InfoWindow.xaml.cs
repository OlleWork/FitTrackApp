using FitTrackApp.ViewModels;
using System.Windows;


namespace FitTrackApp.Views
{
    public partial class InfoWindow : Window
    {
        public InfoWindow()
        {
            InitializeComponent();           
        }

        private void ReturnCommand(object sender, EventArgs e) // This activates the button.
        {

            var workoutsWindow = new WorkoutsWindow(); // Shows WorkoutsWindow again 
            workoutsWindow.Show();

            this.Close(); // Closes about us. 
        }
    }
}
