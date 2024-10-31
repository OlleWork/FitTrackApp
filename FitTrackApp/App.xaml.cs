using System.Windows;

namespace FitTrackApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Only opens MainWindow
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}