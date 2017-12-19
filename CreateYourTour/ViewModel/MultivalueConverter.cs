using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CreateYourTour.ViewModel
{
    public class MultivalueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string[] array = new string[values.Length];
            int i = 0;
            foreach (object obj in values)
            {
                try
                {
                    array[i] = System.Convert.ToString(obj);
                    i++;
                }
                catch
                {
                    array[i] = "";
                    i++;
                }
            }
            
            return array;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
