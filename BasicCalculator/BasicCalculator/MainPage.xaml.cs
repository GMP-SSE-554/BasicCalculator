
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
            DataContext = calculator;
        }

        private void clearCalc_Click(object sender, RoutedEventArgs e)
        {
            calculator.ClearAll();
        }

        private void clearLast_Click(object sender, RoutedEventArgs e)
        {
            calculator.RemoveLast();
        }

        private void answerCalc_Click(object sender, RoutedEventArgs e)
        {
            calculator.PerformCalculations();
        }

        private void op_Click(object sender, RoutedEventArgs e)
        {
            calculator.AddOp(((Button)sender).Content.ToString());
        }
    }
}
