using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace AppTarefa.Conversor
{
  public class TextoTachadoConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      bool valor = (bool)value;
      if (valor)
      {
        return TextDecorations.Strikethrough;
      }
      else
      {
        return TextDecorations.None;
      }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
