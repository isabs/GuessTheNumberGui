using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        public MainWindow()
        {
/*            Modes = new List<CompareStrategy> { new CompareDigits(), new CompareAll() };
            SumLabel = string.Empty;*/
            InitializeComponent();

        }
    }
}
