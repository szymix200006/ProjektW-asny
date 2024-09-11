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
using System.Windows.Shapes;

using System.Collections.Generic;
using System.Linq;

namespace ProjektWłasny
{
    public partial class ConvertCurrencyWindow : Window
    {
        private List<CurrencyRate> _currencyRates;

        public ConvertCurrencyWindow(List<CurrencyRate> currencyRates)
        {
            InitializeComponent();
            _currencyRates = currencyRates;
            LoadCurrencies();
        }

        private void LoadCurrencies()
        {
            var currencies1 = _currencyRates.Select(cr => cr.FromCurrency).Distinct().ToList();
            var currencies2 = _currencyRates.Select(cr => cr.ToCurrency).Distinct().ToList();
            FromCurrencyComboBox.ItemsSource = currencies1;
            ToCurrencyComboBox.ItemsSource = currencies2;
        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(AmountTextBox.Text, out double amount))
            {
                string fromCurrency = FromCurrencyComboBox.SelectedItem as string;
                string toCurrency = ToCurrencyComboBox.SelectedItem as string;

                var rate = _currencyRates.FirstOrDefault(cr => cr.FromCurrency == fromCurrency && cr.ToCurrency == toCurrency)?.Rate;

                if (rate != null)
                {
                    double convertedAmount = amount * rate.Value;
                    ResultTextBlock.Text = $"Converted Amount: {convertedAmount:F2} {toCurrency}";
                }
                else
                {
                    MessageBox.Show("Conversion rate not found");
                }
            }
            else
            {
                MessageBox.Show("Invalid amount");
            }
        }
    }
}

