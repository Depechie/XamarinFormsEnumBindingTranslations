using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace XamarinEnumBinding
{
    public class EnumTypeToItemsSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            var enumType = value as Type;
            if (enumType == null || !enumType.GetTypeInfo().IsEnum)
                return null;

            var values = Enum.GetValues((Type)value).Cast<Enum>();

            return values.Select((enumValue, i) => new EnumItem()
            {
                Index = i,
                Value = TranslationResources.ResourceManager.GetString($"{enumType.Name}_{enumValue}")
            }).ToList();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
