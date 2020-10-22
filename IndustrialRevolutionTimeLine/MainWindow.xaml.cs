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
using System.Text.RegularExpressions;

namespace IndustrialRevolutionTimeLine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public bool AreFieldsEmpty()
        {
            bool areEmpty = false;

            if (Daybox.Text.Length == 0 || MonthBox.Text.Length == 0 || YearBox.Text.Length == 0)
            {
                areEmpty = true;
            }

            return areEmpty;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            int year;
            int day;
            int month;
            if(AreFieldsEmpty() == true)
            {
                MessageBox.Show("Aun no introduce todos lo datos","Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                year = Int32.Parse(YearBox.Text);
                day = Int32.Parse(Daybox.Text);
                month = int.Parse(MonthBox.Text);
                
            }
        }
        private void IsNumber2(object sender, TextCompositionEventArgs e)
        {
            if (!IsNumber(e.Text))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        public static bool IsNumber(string number)
        {
            Regex numberRegularExpression = new Regex(@"\d");

            return numberRegularExpression.IsMatch(number);
        }
    }
}
