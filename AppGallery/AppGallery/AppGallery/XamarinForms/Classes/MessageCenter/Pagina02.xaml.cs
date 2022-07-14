using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static AppGallery.XamarinForms.Classes.MessageCenter.Pagina01;

namespace AppGallery.XamarinForms.Classes.MessageCenter
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Pagina02 : ContentPage
  {
    public Pagina02()
    {
      InitializeComponent();
    }

    private void salvar(object sender, EventArgs e)
    {
      string nome = txtnome.Text;
      var pessoa = new Pessoa() { Nome = nome };

      MessagingCenter.Send<Pagina02, Pessoa>(this, "CadastroPessoa", pessoa);
    }
  }
}