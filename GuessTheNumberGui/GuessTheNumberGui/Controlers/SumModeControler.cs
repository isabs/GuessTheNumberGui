namespace GuessTheNumberGui.Controlers
{
    public class SumModeControler : ViewModelBase
    {
        private string _sumLabel;

        public bool WithSum { get; set; }
        public string SumLabel
        {
            get { return _sumLabel; }
            set
            {
                _sumLabel = value;
                OnPropertyChanged();
            }
        }

        public SumModeControler()
        {
            SumLabel = string.Empty;
        }
    }
}