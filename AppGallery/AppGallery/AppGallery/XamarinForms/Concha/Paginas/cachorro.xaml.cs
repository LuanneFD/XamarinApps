using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Concha.Paginas
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class cachorro : ContentPage
  {
    public cachorro()
    {
      InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
      App.Current.MainPage = new AppBase.Menu();
    }
  }
}