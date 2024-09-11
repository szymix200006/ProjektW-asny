using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektWłasny
{
    public partial class MainWindow : Window
    {
        public List<CurrencyRate> CurrencyRates { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            CurrencyRates = new List<CurrencyRate>
            {
                new CurrencyRate { FromCurrency = "USD", ToCurrency = "EUR", Rate = 0.85 },
                new CurrencyRate { FromCurrency = "USD", ToCurrency = "GBP", Rate = 0.75 },
                new CurrencyRate { FromCurrency = "USD", ToCurrency = "PLN", Rate = 4.03 },
                new CurrencyRate { FromCurrency = "USD", ToCurrency = "YEN", Rate = 1232.45 },
                new CurrencyRate { FromCurrency = "USD", ToCurrency = "LVY", Rate = 2.34 },
                new CurrencyRate { FromCurrency = "USD", ToCurrency = "RUB", Rate = 343.45 },
                new CurrencyRate { FromCurrency = "USD", ToCurrency = "CSK", Rate = 342.56 },
                new CurrencyRate { FromCurrency = "USD", ToCurrency = "KUN", Rate = 1.43 },
                new CurrencyRate { FromCurrency = "USD", ToCurrency = "TBT", Rate = 20392.34 },
                new CurrencyRate { FromCurrency = "USD", ToCurrency = "MON", Rate = 34.56 },
                new CurrencyRate { FromCurrency = "USD", ToCurrency = "CPS", Rate = 233.34 },
                new CurrencyRate { FromCurrency = "USD", ToCurrency = "DIN", Rate = 39.48 }
            };

            CurrencyListView.ItemsSource = CurrencyRates;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ConvertCurrency_Click(object sender, RoutedEventArgs e)
        {
            ConvertCurrencyWindow convertCurrencyWindow = new ConvertCurrencyWindow(CurrencyRates);
            convertCurrencyWindow.ShowDialog();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }
    }

    public class CurrencyRate
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public double Rate { get; set; }
    }
}
