using System;
using System.Windows.Input;
using GuessTheNumberGui.commands;

namespace GuessTheNumberGui.Controlers
{
    public class CurrentNumberControler : ViewModelBase
    {
        private int _currentSum;

        public int DesiredSum { get; set; }

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

        public ICommand SetDigitsClickCommand
        {
            get { return new RelayCommand(SetDigits, () => true); } 
        }

        private void RefreshSum()
        {
            _currentSum = GetSumOfDigits();
            OnPropertyChanged("CurrentSum");
        }

        private void RefreshNumerics()
        {
            OnPropertyChanged("FirstDigit");
            OnPropertyChanged("SecondDigit");
            OnPropertyChanged("ThirdDigit");
            OnPropertyChanged("FourthDigit");

            RefreshSum();
        }

        private int GetSumOfDigits()
        {
            var sum = 0;
            Array.ForEach(CurrentNumber, digit => sum+=digit);

            return sum;
        }

        public void SetDigits()
        {
            SetDigitsWithSum(DesiredSum >= 0 ? DesiredSum : Convert.ToInt32(CurrentNumber.Length*4.5));

            RefreshNumerics();
        }

        private void SetDigitsWithSum( int sum )
        {
            var length = CurrentNumber.Length;

            for (var position = 0; position < length; position++)
            {
                CurrentNumber[position] = sum / (length - position);

                sum -= CurrentNumber[position];
            }
        }
    }
}