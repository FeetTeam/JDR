using PathfinderAdventure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ClientWPF
{
    public class MyStateToBoolConverter : IValueConverter
    {
        public int ValueState { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = value as Character;
            if (value == null) return false;

            if (val.CoinsQuantity.SilverCoins != 2)
            {
                return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}