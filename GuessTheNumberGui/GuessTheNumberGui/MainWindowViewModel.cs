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

        private int[] CurrentNumber { get; set; }

        public int FirstDigit
        {
            get { return CurrentNumber[0]; }
            set { CurrentNumber[0] = value; }
        }

        public int SecondDigit
        {
            get { return CurrentNumber[1]; }
            set { CurrentNumber[1] = value; }
        }

        public int ThirdDigit
        {
            get { return CurrentNumber[2]; }
            set { CurrentNumber[2] = value; }
        }

        public int FourthDigit
        {
            get { return CurrentNumber[3]; }
            set { CurrentNumber[3] = value; }
        }

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

        public bool GameStarted
        {
            get { return _gameStarted;}
            set
            {
                _gameStarted = value;
                OnPropertyChanged();
                OnPropertyChanged("NotGameStarted");
            }
        }

        public bool NotGameStarted
        {
            get { return !_gameStarted; }
            set
            {
                _gameStarted = !value;
                OnPropertyChanged();
                OnPropertyChanged("GameStarted");
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

        public ICommand StartClickCommand { get { return new StartCommand(StartGame, () => true); } }
        public ICommand CheckClickCommand { get { return new StartCommand(Check, () => true); } }

        public MainWindowViewModel()
        {
            CurrentNumber = new[] {0, 0, 0, 0};
            Modes = new List<CompareStrategy>{ new CompareDigits(), new CompareAll() };
            ActualSelectedMode = Modes[0];
            SumLabel = string.Empty;
            StartVisibility = Visibility.Visible;
            CheckVisibility = Visibility.Hidden;
            GameStarted = false;
        }

        public void StartGame()
        {
            if (Number == null || Number.Compare(CurrentNumber))
            { // starting new game! else something bad is happening..
                StartVisibility = Visibility.Hidden;
                CheckVisibility = Visibility.Visible;

                Number = new Number(4, ActualSelectedMode);

                Number.Start();

                GameStarted = true;

                if (WithSum)
                {
                    SumLabel = "Sum of digits should be " + Number.GetSumOfDigits();
                }
            }
            else
            {
                throw new Exception("Clicked Start Button, which cannot exist...");
            }
        }

        public void Check()
        {

            ResultsText = Number.CompareText(CurrentNumber);

            if (Number.Compare(CurrentNumber))
            { //game ends!
                StartVisibility = Visibility.Visible;
                CheckVisibility = Visibility.Hidden;

                GameStarted = false;
                SumLabel = string.Empty;

                Number = null;
            }
        }
    }

    //dodac congratulations z fajerwerkami
}