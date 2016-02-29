using System.Collections.Generic;
using GuessTheNumber.CompareStrategies;

namespace GuessTheNumberGui.Controlers
{
    public class ComboControler : ViewModelBase
    {
        public List<CompareStrategy> Modes { get; set; }
        public CompareStrategy ActualSelectedMode { get; set; }

        public ComboControler()
        {
            Modes = new List<CompareStrategy> { new CompareDigits(), new CompareAll() };
            ActualSelectedMode = Modes[0];
        }
    }
}