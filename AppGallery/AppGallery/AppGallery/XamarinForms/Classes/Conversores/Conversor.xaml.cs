using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Classes.Conversores
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Conversor : ContentPage
  {
    public Conversor()
    {
      InitializeComponent();
      lista01.ItemsSource = new List<Veiculo> {
        new Veiculo { Marca = "FIAT", Modelo = "UNO", Valor = 39900, Opcionais = "1,2,3" },
        new Veiculo { Marca = "FORD", Modelo = "KA", Valor = 49900, Opcionais = "2,3" },
        new Veiculo { Marca = "FORD", Modelo = "FIESTA", Valor = 59900, Opcionais = "1,2" }
      };
    }

    public class Veiculo
    {
      public string Marca { get; set; } 
      public string Modelo { get; set; }
      public double Valor { get; set; }
      public string Opcionais { get; set; } 
    }
  }
}