using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Estilos.DynamicStyle
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Dynamic : ContentPage
  {
    public Dynamic()
    {
      InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
      Resources["PrimaryColor"] = Color.FromHex(cornova.Text);
    }
  }
}