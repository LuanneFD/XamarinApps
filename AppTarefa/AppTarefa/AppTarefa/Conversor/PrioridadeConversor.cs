using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace AppTarefa.Conversor
{
  public class PrioridadeConversor : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      string prioridade = (string)value;
      if (prioridade == "Baixa")
      {
        return Application.Current.Resources["PrioridadeBaixa"];
      }
      if (prioridade == "Normal")
      {
        return Application.Current.Resources["PrioridadeNormal"];
      }
      if (prioridade == "Alta")
      {
        return Application.Current.Resources["PrioridadeAlta"];
      }
      return Application.Current.Resources["PrioridadeNormal"];
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
