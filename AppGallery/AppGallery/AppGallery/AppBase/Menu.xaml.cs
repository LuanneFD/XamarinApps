using AppGallery.AppBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.AppBase
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Menu
  {
    public Menu()
    {
      InitializeComponent();
    }

    private void AbrirPaginaFixa(object sender, EventArgs e)
    {
      var eventargs = (TappedEventArgs)e;
      Type tipo = null;
      switch (eventargs.Parameter)
      {
        case "Home":
          tipo = typeof(Inicio);
          break;
        case "Creditos":
          tipo = typeof(Creditos);
          break;
      }
      var pagina = new NavigationPage((Page)Activator.CreateInstance(tipo));
      ((FlyoutPage)App.Current.MainPage).Detail = pagina;
      ((FlyoutPage)App.Current.MainPage).IsPresented = false;
    }
  }
}