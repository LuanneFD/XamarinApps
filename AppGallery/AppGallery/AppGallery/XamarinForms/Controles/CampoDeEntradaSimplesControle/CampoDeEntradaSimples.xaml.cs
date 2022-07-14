using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Controles.CampoDeEntradaSimplesControle
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class CampoDeEntradaSimples : ContentPage
  {
    public CampoDeEntradaSimples()
    {
      InitializeComponent();
    }

    private void Entry_Focused(object sender, FocusEventArgs e)
    {
      focus.Text = "focado";
    }

    private void Entry_Unfocused(object sender, FocusEventArgs e)
    {
      unfocus.Text = "sem foco";
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
      textchange.Text = "texto alterado";
    }

    private void Entry_Completed(object sender, EventArgs e)
    {
      //botão de concluir do teclado
      complete.Text = "texto completo";
    }
  }
}