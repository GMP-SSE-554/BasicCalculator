using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BasicCalculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Calculator calculator;
        public MainPage()
        {
            InitializeComponent();
            calculator = new Calculator();
        }

        private void leftParenthesis_Click(object sender, RoutedEventArgs e)
        {
            calculator.CalcString += "(";
        }

        private void rightParenthesis_Click(object sender, RoutedEventArgs e)
        {
            calculator.CalcString += ")";
        }

        private void clearCalc_Click(object sender, RoutedEventArgs e)
        {
            calculator.CalcString = "";
        }

        private void multiplyCalc_Click(object sender, RoutedEventArgs e)
        {
            calculator.CalcString += "*";
        }

        private void divideCalc_Click(object sender, RoutedEventArgs e)
        {
            calculator.CalcString += "/";
        }

        private void addCalc_Click(object sender, RoutedEventArgs e)
        {
            calculator.CalcString += "+";
        }

        private void subtractCalc_Click(object sender, RoutedEventArgs e)
        {
            calculator.CalcString += "-";
        }

        private void answerCalc_Click(object sender, RoutedEventArgs e)
        {
            calculator.PerformCalculation();
        }

        private void numDecimal_Click(object sender, RoutedEventArgs e)
        {
            calculator.CalcString += ".";
        }

        private void numZero_Click(object sender, RoutedEventArgs e)
        {
            calculator.CalcString += "0";
        }

        private void numOne_Click(object sender, RoutedEventArgs e)
        {
            calculator.CalcString += "1";
        }

        private void numTwo_Click(object sender, RoutedEventArgs e)
        {
            calculator.CalcString += "2";
        }

        private void numThree_Click(object sender, RoutedEventArgs e)
        {
            calculator.CalcString += "3";
        }

        private void numFour_Click(object sender, RoutedEventArgs e)
        {
            calculator.CalcString += "4";
        }

        private void numFive_Click(object sender, RoutedEventArgs e)
        {
            calculator.CalcString += "5";
        }

        private void numSix_Click(object sender, RoutedEventArgs e)
        {
            calculator.CalcString += "6";
        }

        private void numSeven_Click(object sender, RoutedEventArgs e)
        {
            calculator.CalcString += "7";
        }

        private void numEight_Click(object sender, RoutedEventArgs e)
        {
            calculator.CalcString += "8";
        }

        private void numNine_Click(object sender, RoutedEventArgs e)
        {
            calculator.CalcString += "9";
        }
    }
}
