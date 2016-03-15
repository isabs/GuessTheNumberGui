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

        public ICommand SetDigitsClickCommand { get { return new RelayCommand(SetDigits, () => true); } }

        public CurrentNumberControler()
        {
            CurrentNumber = new[] {0, 0, 0, 0};
        }

        public int Digit0
        {
            get { return CurrentNumber[0]; }
            set { SetDigit(0, value); }
        }

        public int Digit1
        {
            get { return CurrentNumber[1]; }
            set { SetDigit(1, value); }
        }

        public int Digit2
        {
            get { return CurrentNumber[2]; }
            set {SetDigit(2, value); }
        }

        public int Digit3
        {
            get { return CurrentNumber[3]; }
            set { SetDigit(3, value); }
        }

        public void SetDigits()
        {
            SetDigitsWithSum(DesiredSum >= 0 ? DesiredSum : Convert.ToInt32(CurrentNumber.Length * 4.5));

            RefreshNumerics();
        }

        private void SetDigitsWithSum(int sum)
        {
            var length = CurrentNumber.Length;

            for (var position = 0; position < length; position++)
            {
                CurrentNumber[position] = sum / (length - position);

                sum -= CurrentNumber[position];
            }
        }

        private void RefreshSum()
        {
            _currentSum = GetSumOfDigits();
            OnPropertyChanged("CurrentSum");
        }

        private void RefreshNumerics()
        {
            OnPropertyChanged("Digit1");
            OnPropertyChanged("Digit2");
            OnPropertyChanged("Digit3");
            OnPropertyChanged("Digit0");

            RefreshSum();
        }

        private int GetSumOfDigits()
        {
            var sum = 0;
            Array.ForEach(CurrentNumber, digit => sum+=digit);

            return sum;
        }

        private void SetDigit(int where, int value)
        {
            CurrentNumber[where] = value;

            OnPropertyChanged("Digit" + where);

            RefreshSum();
        }
    }
}