using System;

namespace GuessTheNumberGui.Controlers
{
    public class CurrentNumberControler : ViewModelBase
    {
        private int _currentSum;

        public int[] CurrentNumber { get; set; }

        public string CurrentSum => "Current sum: " + _currentSum;


        public CurrentNumberControler()
        {
            CurrentNumber = new[] {0, 0, 0, 0};
        }

        public int FirstDigit
        {
            get { return CurrentNumber[0]; }
            set
            {
                CurrentNumber[0] = value;
                OnPropertyChanged();
                RefreshSum();
            }
        }

        public int SecondDigit
        {
            get { return CurrentNumber[1]; }
            set
            {
                CurrentNumber[1] = value;
                OnPropertyChanged();
                RefreshSum();
            }
        }

        public int ThirdDigit
        {
            get { return CurrentNumber[2]; }
            set
            {
                CurrentNumber[2] = value;
                OnPropertyChanged();
                RefreshSum();
            }
        }

        public int FourthDigit
        {
            get { return CurrentNumber[3]; }
            set
            {
                CurrentNumber[3] = value;
                OnPropertyChanged();
                RefreshSum();
            }
        }

        private void RefreshSum()
        {
            _currentSum = GetSumOfDigits();
            OnPropertyChanged("CurrentSum");
        }

        private int GetSumOfDigits()
        {
            var sum = 0;
            Array.ForEach(CurrentNumber, digit => sum+=digit);

            return sum;
        }
    }
}