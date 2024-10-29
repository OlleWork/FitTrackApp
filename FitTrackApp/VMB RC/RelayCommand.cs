using System.Windows.Input;

namespace FitTrackApp.VMB_RC
{
    // RelayCommand-klassen implementerar ICommand-gränssnittet och används ofta inom MVVM-mönstret
    // för att koppla kommando-logik till användargränssnittet, t.ex. knappar eller menyer.
    class RelayCommand : ICommand
    {
        // Fält för att hålla referenser till metoder som definierar vad som ska göras (execute)
        // och om kommandot kan köras (canExecute).
        private Action<object> execute;
        private Func<object, bool> canExecute;

        // Event som signalerar när kommandots möjlighet att exekveras har förändrats. 
        // CommandManager hanterar återanrop till CanExecute när relevanta händelser inträffar,
        // t.ex. att en knapp blivit aktiverad/deaktiverad.
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Konstruktor som tar in två parametrar: 
        // 'execute' är en metod som ska köras när kommandot exekveras,
        // och 'canExecute' (valfri) bestämmer om kommandot kan exekveras baserat på ett villkor.
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute; // Tilldelar execute-fältet metoden som ska köras.
            this.canExecute = canExecute; // Tilldelar canExecute-fältet metoden som avgör om kommandot kan köras.
        }

        // Bestämmer om kommandot kan köras eller inte, baserat på canExecute-metoden.
        // Om canExecute inte är tilldelad (null), returnerar metoden true som standard.
        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        // Exekverar den logik som tilldelats via execute-metoden när kommandot körs,
        // och tar eventuellt ett parameterobjekt.
        public void Execute(object? parameter)
        {
            execute(parameter);
        }
    }
}
