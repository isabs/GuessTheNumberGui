using System;
using System.Windows.Input;
using GuessTheNumber;
using GuessTheNumberGui.commands;

namespace GuessTheNumberGui.Controlers
{
    public class GameFlowControler : ViewModelBase
    {
        private CurrentNumberControler _currentNumberControler;
        private ComboControler _comboControler;
        private SumModeControler _sumModeControler;

        public  ButtonVisibilityControler ButtonVisibilityControler { get; set; }

        private bool _gameEnded;
        private string _resultsText;

        private Number Number { get; set; }

        public ICommand StartClickCommand { get { return new RelayCommand(StartGame, () => true); } }
        public ICommand CheckClickCommand { get { return new RelayCommand(Check, () => true); } }



        public GameFlowControler(CurrentNumberControler currentNumberControler, ComboControler comboControler, SumModeControler sumModeControler)
        {
            ButtonVisibilityControler = new ButtonVisibilityControler();

            _currentNumberControler = currentNumberControler;
            _comboControler = comboControler;
            _sumModeControler = sumModeControler;

            GameEnded = true;
        }

        public void StartGame()
        {
            if (Number == null || Number.Compare(_currentNumberControler.CurrentNumber))
            {
                ButtonVisibilityControler.MakeCheckVisible();

                Number = new Number(4, _comboControler.ActualSelectedMode);

                Number.Start();

                GameEnded = false;

                if (_sumModeControler.WithSum)
                {
                    _sumModeControler.SumLabel = string.Format("Sum of digits should be " + Number.GetSumOfDigits());
                    _currentNumberControler.DesiredSum = Number.GetSumOfDigits();
                }
                else
                {
                    _currentNumberControler.DesiredSum = -1;
                }
            }
            else
            {
                throw new Exception("Clicked Start Button, which cannot exist...");
            }
        }

        public void Check()
        {

            ResultsText = Number.CompareText(_currentNumberControler.CurrentNumber);

            if (Number.Compare(_currentNumberControler.CurrentNumber))
            {
                ButtonVisibilityControler.MakeStartVisible();

                GameEnded = true;
                _sumModeControler.SumLabel = string.Empty;

                Number = null;
            }
        }

        public bool GameEnded
        {
            get { return _gameEnded; }
            set
            {
                _gameEnded = value;
                OnPropertyChanged();
            }
        }

        public string ResultsText
        {
            get { return _resultsText; }
            set
            {
                _resultsText = value;
                OnPropertyChanged();
            }
        }
    }
}