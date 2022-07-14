using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Paginas.Modal
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Conteudo01 : ContentPage
  {
    public Conteudo01()
    {
      InitializeComponent();
    }

    private void AbrirModal(object sender, EventArgs e)
    {
      Navigation.PushModalAsync(new PaginaDeModal()); 
      // usando modal não é necessário instanciar uma navigationpage no App.xaml
      //Não terá barra de navegação na página e o modal só é chamado caso o usuário execute uma ação.
      //O modal abre na tela com movimento de baixo pra cima.
    }
  }
}