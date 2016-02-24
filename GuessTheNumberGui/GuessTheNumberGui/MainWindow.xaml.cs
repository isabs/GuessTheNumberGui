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
using Xceed.Wpf.Toolkit;

namespace GuessTheNumberGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<CompareStrategy> Modes { get; set; }
        public string ButtonText { get; private set; }
        private Number Number { get; set; }

        public MainWindow()
        {
            Modes = new List<CompareStrategy> {new CompareDigits(), new CompareAll()};
            ButtonText = "Start";
            InitializeComponent();
            this.DataContext = this;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnCheckStart_Click(object sender, RoutedEventArgs e)
        {
            var value = new[] { SetUninitializedNumeric(txtNumber1), SetUninitializedNumeric(txtNumber2),
                SetUninitializedNumeric(txtNumber3), SetUninitializedNumeric(txtNumber4) };

            Console.WriteLine(ButtonText);

            if (ButtonText == "Start" && (Number == null || Number.Compare(value)))
            {
                ButtonText = "Check!";

                

                //Number = new Number(cmbMode.GetValue());
            }
            else
            {
                ButtonText = "Meh!";
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
