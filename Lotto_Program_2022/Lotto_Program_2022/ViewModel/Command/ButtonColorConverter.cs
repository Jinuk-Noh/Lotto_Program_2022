using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using Lotto_Program_2022.Model;


namespace Lotto_Program_2022.ViewModel.Command
{
    public class ButtonColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush color = new SolidColorBrush(Colors.Transparent);
            if (value == null)
            {
                return color;
            }

            NumberStatus numStatus = (NumberStatus)value;

            if (numStatus == NumberStatus.Right)
            {
                color = new SolidColorBrush(Colors.Red);
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
