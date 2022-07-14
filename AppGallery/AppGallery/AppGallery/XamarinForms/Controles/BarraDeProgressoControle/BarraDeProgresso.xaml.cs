using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Controles.BarraDeProgressoControle
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BarraDeProgresso : ContentPage
  {
    public BarraDeProgresso()
    {
      InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
      barraProgesso.ProgressTo(0.6, 800, Easing.CubicIn); //800 milisegundos
    }
  }
}