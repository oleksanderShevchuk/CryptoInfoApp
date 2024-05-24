using System.Globalization;
using System.Windows.Data;

namespace CryptoInfoApp.Helpers.Converters
{
    public class PriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            if (value is decimal price)
            {
                string formattedPrice = price.ToString("#,0.####", CultureInfo.InvariantCulture);
                return "$" + formattedPrice;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
