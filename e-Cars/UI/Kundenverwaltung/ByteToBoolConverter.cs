using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using e_Cars.UI.Kundenverwaltung;

namespace e_Cars.UI.Kundenverwaltung
{
    public class ByteToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {

            byte[] b = (byte[])value;

            if (b == null)
                return false;
            else
                return true;

        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            // Do the conversion from visibility to bool
            return null;
        }

    }
}
