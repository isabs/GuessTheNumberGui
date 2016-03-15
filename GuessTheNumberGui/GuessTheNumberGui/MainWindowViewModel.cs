using GuessTheNumberGui.Controlers;

namespace GuessTheNumberGui
{
    public class MainWindowViewModel : ViewModelBase
    {   // TODO: further refactoring
        // TODO: Adding button to automatic setting up-downs based on desired sum
        // TODO: Super flashy congratulations view
        // TODO: Number of wins, steps, ranking; this must be saved to db

        //TODO: easy - Blocking numerics until the game starts
        //TODO: easy - add step label



        public CurrentNumberControler CurrentNumberControler { get; private set; }
        public ComboControler ComboControler { get; set; }
        public SumModeControler SumModeControler { get; set; }
        public GameFlowControler GameFlowControler { get; set; }

        public MainWindowViewModel()
        {
            CurrentNumberControler = new CurrentNumberControler();
            ComboControler = new ComboControler();
            SumModeControler = new SumModeControler();

            GameFlowControler = new GameFlowControler(CurrentNumberControler, ComboControler, SumModeControler);
        }
    }
    
}