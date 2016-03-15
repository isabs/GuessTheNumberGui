using System;
using System.Collections.Generic;
using System.Linq;

namespace GuessTheNumberGui.Controlers
{
    public class CurrentNumberControler2 : ViewModelBase
    {
        private int _currentSum;
        public List<NumericControler> Numerics { get; set; }
        public int DesiredSum { get; set; }
        public string CurrentSum => "Current sum: " + _currentSum;
        public int[] CurrentNumber => Numerics.Select(numeric => numeric.Value).ToArray();

        public CurrentNumberControler2 (int number = 4)
        {
            Numerics = new List<NumericControler>();

            for (var position = 0; position < number; position++)
            {
                Numerics.Add(new NumericControler(this));
            }
        }

        public void SetAvg()
        {
            var sum = DesiredSum;
            var length = Numerics.Count;

            for (var position = 0; position < length; position++)
            {
                Numerics[position].Avg = sum / (length - position);

                sum -= Numerics[position].Avg;
            }
        }

        public void RefreshSum()
        {
            var sum = 0;
            Numerics.ForEach(digit => sum += digit.Value);

            _currentSum = sum;
            OnPropertyChanged("CurrentSum");
        }
    }
}