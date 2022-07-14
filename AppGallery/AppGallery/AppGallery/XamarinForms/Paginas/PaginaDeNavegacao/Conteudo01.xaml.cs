using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Paginas.PaginaDeNavegacao
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Conteudo01 : ContentPage
  {
    public Conteudo01()
    {
      InitializeComponent();
    }

    private void AbrirPagina02(object sender, EventArgs e)
    {
      Navigation.PushAsync(new Conteudo02()); 
      //Puxa a página desejada e sobrepõe a página atual
      //Neste momento o botão de voltar já aparece automaticamente
    }
  }
}