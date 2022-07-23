using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maui_lotto.Converters
{
    public class LottoNumColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Brush brush = Colors.White;
            int num = int.Parse(value.ToString());
            if(num <= 10)
                brush = Color.FromHex("#FBC400");
            else if (num <= 20)
                brush = Color.FromHex("#1E47D6");
            else if (num <= 30)
                brush = Color.FromHex("#FF7272");
            else if (num <= 40)
                brush = Color.FromHex("#1E1E1E");
            else
                brush = Color.FromHex("#55B155");

            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
    }
}
