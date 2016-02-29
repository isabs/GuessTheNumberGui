using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using GuessTheNumber;
using GuessTheNumber.CompareStrategies;
using GuessTheNumberGui.commands;
using Xceed.Wpf.Toolkit;

namespace GuessTheNumberGui
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Visibility _startVisibility ;
        private Visibility _checkVisibility;
        private bool _gameStarted;
        private string _sumLabel;
        private string _resultsText;

        #region numeric up down

        public CurrentNumberControler CurrentNumberControler { get; private set; }

        #endregion


        public List<CompareStrategy> Modes { get; set; }
        public CompareStrategy ActualSelectedMode { get; set; }
        public bool WithSum { get; set; }

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


        public string SumLabel
        {
            get { return _sumLabel; }
            set
            {
                _sumLabel = value;
                OnPropertyChanged();
            }
        }

        private Number Number { get; set; }

/*        public bool GameStarted
        {
            get { return _gameStarted;}
            set
            {
                _gameStarted = value;
                OnPropertyChanged();
                OnPropertyChanged("GameEnded");
            }
        }*/

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
            Modes = new List<CompareStrategy>{ new CompareDigits(), new CompareAll() };
            ActualSelectedMode = Modes[0];
            SumLabel = string.Empty;
            StartVisibility = Visibility.Visible;
            CheckVisibility = Visibility.Hidden;
            GameEnded = true;
        }

        public void StartGame()
        {
            if (Number == null || Number.Compare(CurrentNumberControler.CurrentNumber))
            { // starting new game! else something bad is happening..
                StartVisibility = Visibility.Hidden;
                CheckVisibility = Visibility.Visible;

                Number = new Number(4, ActualSelectedMode);

                Number.Start();

                GameEnded = false;

                if (WithSum)
                {
                    SumLabel = string.Format("Sum of digits should be " + Number.GetSumOfDigits());
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
            { //game ends!
                StartVisibility = Visibility.Visible;
                CheckVisibility = Visibility.Hidden;

                GameEnded = true;
                SumLabel = string.Empty;

                Number = null;
            }
        }
    }

    //add congratulations view with fireworks
}