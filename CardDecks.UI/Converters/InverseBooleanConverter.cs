using System.Globalization;
using System.Windows.Data;

namespace CardDecks.UI.Converters;

public class InverseBooleanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return targetType == typeof(bool?) ?
            !(bool)value :
            throw new InvalidCastException("Передан неверный тип. Ожидался булевый");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
