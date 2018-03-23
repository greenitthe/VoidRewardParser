using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace VoidRewardParser.Converters
{
    public class DucatRatioColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush ratioBrush = new SolidColorBrush(Colors.Black);

            float ducatRatio;

            if(!float.TryParse((String)value, out ducatRatio))
            {
                return ratioBrush;
            }

            // Whelp can't switch floats
            if(ducatRatio > 0.00f)
            {
                ratioBrush.Color = Colors.Red;
            }
            if(ducatRatio > 1.50f)
            {
                ratioBrush.Color = Colors.Orange;
            }
            if(ducatRatio > 2.50f)
            {
                ratioBrush.Color = Colors.Yellow;
            }
            if(ducatRatio > 5.00f)
            {
                ratioBrush.Color = Colors.Green;
            }
            if(ducatRatio > 10.00f)
            {
                ratioBrush.Color = Colors.Teal;
            }
            return ratioBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
