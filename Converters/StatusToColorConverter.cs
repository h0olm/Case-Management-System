using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CaseManagementSystem.Converters
{
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string status = value as string;

            if (status == null)
            {
                return Brushes.Transparent;
            }

            return status switch
            {
                "Open" => Brushes.Red,
                "In Progress" => Brushes.Yellow,
                "Closed" => Brushes.Green,
                _ => Brushes.Transparent,
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
