using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace DellyShopApp.Converters {

    public class BoolToObjectConverter<T> : IValueConverter {
        public T TrueObject { set; get; }

        public T FalseObject { set; get; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if ( value is bool val ) {
                return val ? TrueObject : FalseObject;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return ( ( T ) value ).Equals( TrueObject );
        }
    }
}
