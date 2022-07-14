using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Estilos.ImplicitStyle
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Implicit : ContentPage
  {
    public Implicit()
    {
      InitializeComponent();
    }
  }
  public class MeuBotao : Button
  {
    public MeuBotao()
    {
      Text = "Meu botão";
    }
  }
}