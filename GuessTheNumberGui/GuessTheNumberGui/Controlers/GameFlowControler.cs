using System;
using System.Windows;
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

        private Visibility _startVisibility;
        private Visibility _checkVisibility;
        private bool _gameStarted;
        private string _resultsText;

        private Number Number { get; set; }

        public ICommand StartClickCommand { get { return new RelayCommand(StartGame, () => true); } }
        public ICommand CheckClickCommand { get { return new RelayCommand(Check, () => true); } }

        public Visibility StartVisibility
        {
            get { return _startVisibility; }
            set
            {
                _startVisibility = value;
                OnPropertyChanged();
            }
        }

        public Visibility CheckVisibility
        {
            get { return _checkVisibility; }
            set
            {
                _checkVisibility = value;
                OnPropertyChanged();
            }
        }

        public GameFlowControler(CurrentNumberControler currentNumberControler, ComboControler comboControler, SumModeControler sumModeControler)
        {
            StartVisibility = Visibility.Visible;
            CheckVisibility = Visibility.Hidden;
            _currentNumberControler = currentNumberControler;
            _comboControler = comboControler;
            _sumModeControler = sumModeControler;
            GameEnded = true;
        }

        public void StartGame()
        {
            if (Number == null || Number.Compare(_currentNumberControler.CurrentNumber))
            {
                StartVisibility = Visibility.Hidden;
                CheckVisibility = Visibility.Visible;

                Number = new Number(4, _comboControler.ActualSelectedMode);

                Number.Start();

                GameEnded = false;

                if (_sumModeControler.WithSum)
                {
                    _sumModeControler.SumLabel = string.Format("Sum of digits should be " + Number.GetSumOfDigits());
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
                StartVisibility = Visibility.Visible;
                CheckVisibility = Visibility.Hidden;

                GameEnded = true;
                _sumModeControler.SumLabel = string.Empty;

                Number = null;
            }
        }

        

        public bool GameEnded
        {
            get { return _gameStarted; }
            set
            {
                _gameStarted = value;
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