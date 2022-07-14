using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Estilos.TrocarTema
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Tema : ContentPage
  {
    private bool light = false;
    public Tema()
    {
      InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
      if (light)
      {
        Resources = new DarkTheme();
        //Alterar o tema global : App.Current.Resources = new DarkTheme();
      }
      else
      {
        Resources = new LigthTheme();
        light = true;
      }
    }
  }
}