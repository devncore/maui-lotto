using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maui_lotto.Converters
{
    public class PrizeMoneyToMillionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            string text = "";            
            long amount = (long)value;            

            var hundred_million = amount / 100000000;
            if (hundred_million > 0)
            {
                text += $"{hundred_million:N0}억";
            }

            var ten_million = amount % 100000000 / 10000000;
            if (ten_million > 0)
            {
                text += $"{ten_million:N0}천";
            }

            text += "만원";

            return text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
    }
}
