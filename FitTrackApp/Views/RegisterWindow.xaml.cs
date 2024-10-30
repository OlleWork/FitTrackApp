using FitTrackApp.Models;
using FitTrackApp.ViewModels;
using System.Windows;

namespace FitTrackApp.Views
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            DataContext = new RegisterViewModel(new List<User>());
        }
    }
}