using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CryptoInfoApp.Helpers.Converters
{
    public class MarketCapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Int64 price)
            {
                return price.ToString("C0", new CultureInfo("en-US"));
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MessageBox.Show("ConvertBack is not implement!");
            return null!;
        }
    }
}
