using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GuessTheNumber;
using GuessTheNumber.CompareStrategies;
using GuessTheNumberGui.commands;
using Xceed.Wpf.Toolkit;

namespace GuessTheNumberGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<CompareStrategy> Modes { get; set; }
        public string SumLabel { get; set; }
        private Number Number { get; set; }

        public ICommand StartClickCommand { get { return new StartCommand(StartGame, () => true); } }

        public MainWindow()
        {
            Modes = new List<CompareStrategy> {new CompareDigits(), new CompareAll()};
            SumLabel = string.Empty;
            InitializeComponent();
            this.DataContext = this;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void StartGame()
        {
            var value = new[] { SetUninitializedNumeric(txtNumber1), SetUninitializedNumeric(txtNumber2),
                SetUninitializedNumeric(txtNumber3), SetUninitializedNumeric(txtNumber4) };

            CompareStrategy comparer; 

            if((CompareStrategy)cmbMode.SelectedItem == null) comparer = new CompareAll();
            else comparer = (CompareStrategy)cmbMode.SelectedItem;

            if (Number == null || Number.Compare(value))
            {
                var withSum = chkWithSum.IsChecked ?? false; 

                btnStart.Visibility = Visibility.Hidden;
                btnCheck.Visibility = Visibility.Visible;

                Number = new Number(4, comparer);

                Number.Start();

                cmbMode.IsReadOnly = true;

                if (withSum)
                {
                    SumLabel = "Sum of digits should be " + Number.GetSumOfDigits();
                }

                //Number = new Number(cmbMode.GetValue());
            }
            else
            {
                throw new Exception("Clicked Start Button, which cannot exist...");
            }
        }

        private int SetUninitializedNumeric(IntegerUpDown txtNumber)
        {
            if (txtNumber.Value == null)
                txtNumber.Value = 0;

            return txtNumber.Value.GetValueOrDefault();
        }
    }
}
