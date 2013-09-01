using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using SelaResortBL;
using Common;

namespace SelaResortUI.BindingUtilities
{
    class EmployeeStringToEnumValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Positions field;
            if (parameter != null)
            {
                field = (Positions)parameter;
                return field.ToString();
            }
            else if (value != null)
            {
                field = (Positions)value;
                return (int)field;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (Positions)value;
        }
    }
}
