using System.Windows.Input;
using GuessTheNumberGui.commands;

namespace GuessTheNumberGui.Controlers
{
    public class NumericControler : ViewModelBase
    {
        private readonly CurrentNumberControler2 _currentNumberControler;
        private int _value;
        private int _avg;

        public int Avg
        {
            get
            {
                return _avg;
            }
            set
            {
                _avg = value;
                OnPropertyChanged();
            }
        }

        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value; 
                OnPropertyChanged();
                _currentNumberControler.RefreshSum();
            }
        }

        public ICommand BtnSetZeroClick { get { return new RelayCommand(SetZero, () => true); } }
        public ICommand BtnSetAvgClick { get { return new RelayCommand(SetAvg, () => true); } }
        public ICommand BtnSetMaxClick { get { return new RelayCommand(SetMax, () => true); } }

        public NumericControler(CurrentNumberControler2 currentNumberControler2)
        {
            _currentNumberControler = currentNumberControler2;
            Value = 0;
            Avg = 5;
        }


        private void SetZero()
        {
            Value = 0;
        }

        private void SetAvg()
        {
            Value = Avg;
        }

        private void SetMax()
        {
            Value = 9;
        }
    }
}