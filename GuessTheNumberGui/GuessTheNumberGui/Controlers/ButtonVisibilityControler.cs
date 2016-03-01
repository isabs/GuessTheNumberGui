using System.Windows;

namespace GuessTheNumberGui.Controlers
{
    public class ButtonVisibilityControler : ViewModelBase
    {
        private Visibility _startVisibility;
        private Visibility _checkVisibility;

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

        public ButtonVisibilityControler()
        {
            MakeStartVisible();
        }

        public void MakeCheckVisible()
        {
            StartVisibility = Visibility.Hidden;
            CheckVisibility = Visibility.Visible;
        }

        public void MakeStartVisible()
        {
            StartVisibility = Visibility.Visible;
            CheckVisibility = Visibility.Hidden;
        }
    }
}