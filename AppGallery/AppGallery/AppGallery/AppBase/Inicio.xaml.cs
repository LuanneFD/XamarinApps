using AppGallery.AppBase.ViewModel;
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
  public partial class Inicio : ContentPage
  {
    public Inicio()
    {
      InitializeComponent();
    }

    private void Buscar(object sender, EventArgs e)
    {
      var textopesquisado = entrySearch.Text;
      var viewmodel = (InicioViewModel)BindingContext;
      viewmodel.Pesquisa(textopesquisado);
    }
  }
}