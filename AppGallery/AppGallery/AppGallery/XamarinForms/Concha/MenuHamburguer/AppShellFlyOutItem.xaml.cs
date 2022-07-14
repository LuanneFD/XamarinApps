using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Concha.MenuHamburguer
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class AppShellFlyOutItem : Shell
  {
    public AppShellFlyOutItem()
    {
      InitializeComponent();
    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {
      App.Current.MainPage = new AppBase.Menu();
    }
  }
}