using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPFMVVMv_NET4_0.View
{
    public class InvalidAgeConverter : IValueConverter
    {
        private int GetAgeValue(object value)
        {
            if (value == null)
                return -1;
            int temp;
            int.TryParse(value.ToString(), out temp);
            return temp;
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return string.Empty;
            var temp = GetAgeValue(value);
            if (temp <= 0)
                return string.Empty;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
       {
            var temp = GetAgeValue(value);
            if (temp <= 0) 
                return -1;
            return value;
        }
    }
}
