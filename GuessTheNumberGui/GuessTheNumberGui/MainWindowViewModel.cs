using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using GuessTheNumber;
using GuessTheNumber.CompareStrategies;
using GuessTheNumberGui.commands;
using GuessTheNumberGui.Controlers;
using Xceed.Wpf.Toolkit;

namespace GuessTheNumberGui
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Visibility _startVisibility ;
        private Visibility _checkVisibility;
        private bool _gameStarted;
        private string _resultsText;

        public CurrentNumberControler CurrentNumberControler { get; private set; }
        public ComboControler ComboControler { get; set; }
        public SumModeControler SumModeControler { get; set; }

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

        private Number Number { get; set; }

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
            get { return _resultsText;  }
            set
            {
                _resultsText = value;
                OnPropertyChanged();
            }
        }

        public ICommand StartClickCommand { get { return new RelayCommand(StartGame, () => true); } }
        public ICommand CheckClickCommand { get { return new RelayCommand(Check, () => true); } }

        public MainWindowViewModel()
        {
            CurrentNumberControler = new CurrentNumberControler();
            ComboControler = new ComboControler();
            SumModeControler = new SumModeControler();
          
            StartVisibility = Visibility.Visible;
            CheckVisibility = Visibility.Hidden;
            GameEnded = true;
        }

        public void StartGame()
        {
            if (Number == null || Number.Compare(CurrentNumberControler.CurrentNumber))
            {
                StartVisibility = Visibility.Hidden;
                CheckVisibility = Visibility.Visible;

                Number = new Number(4, ComboControler.ActualSelectedMode);

                Number.Start();

                GameEnded = false;

                if (SumModeControler.WithSum)
                {
                    SumModeControler.SumLabel = string.Format("Sum of digits should be " + Number.GetSumOfDigits());
                }
            }
            else
            {
                throw new Exception("Clicked Start Button, which cannot exist...");
            }
        }

        public void Check()
        {

            ResultsText = Number.CompareText(CurrentNumberControler.CurrentNumber);

            if (Number.Compare(CurrentNumberControler.CurrentNumber))
            {
                StartVisibility = Visibility.Visible;
                CheckVisibility = Visibility.Hidden;

                GameEnded = true;
                SumModeControler.SumLabel = string.Empty;

                Number = null;
            }
        }
    }

    //add congratulations view with fireworks
}