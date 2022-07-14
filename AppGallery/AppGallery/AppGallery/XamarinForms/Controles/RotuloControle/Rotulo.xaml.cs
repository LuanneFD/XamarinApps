using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Controles.RotuloControle
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Rotulo : ContentPage
  {
    public Rotulo()
    {
      InitializeComponent();
      BindingContext = new Pessoa()
      {
        Nome = "João",
        DataNascimento = DateTime.Now.AddYears(-30)
      };
    }

    public class Pessoa
    {
      public string Nome { get; set; }
      public DateTime DataNascimento { get; set; }
    }
  }
}