using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Concha.MenuHamburguer.Paginas
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Raposa : ContentPage
  {
    public Raposa()
    {
      InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
      //Rotas absolutas:
      //exoticos > pequenos > Coala
      //shell.current.gotoasync("//exoticos/pequenos/coala")

      //Rotas relativas
      //raposa: shell.current.gotoasync("../coala")

      //Caso o a rota seja unica, pode ser pesquisado pelo nome
      //shell.current.gotoasync("../coala")

      await Shell.Current.GoToAsync($"//exoticos/pequenos/coala?id={78}&tipo=numero");
    }
  }
}