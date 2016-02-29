using System;

namespace GuessTheNumberGui
{
    public class CurrentNumberControler : ViewModelBase
    {
        public int[] CurrentNumber { get; set; }


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
            }
        }

        public int SecondDigit
        {
            get { return CurrentNumber[1]; }
            set
            {
                CurrentNumber[1] = value;
                OnPropertyChanged();
            }
        }

        public int ThirdDigit
        {
            get { return CurrentNumber[2]; }
            set
            {
                CurrentNumber[2] = value;
                OnPropertyChanged();
            }
        }

        public int FourthDigit
        {
            get { return CurrentNumber[3]; }
            set
            {
                CurrentNumber[3] = value;
                OnPropertyChanged();
            }
        }

        public int GetSumOfDigits()
        {
            var sum = 0;
            Array.ForEach(CurrentNumber, digit => sum+=digit);

            return sum;
        }
    }
}