using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Classes.MessageCenter
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Pagina01 : ContentPage
  {
    public class Pessoa
    {
      public string Nome { get; set; }
    }
    public ObservableCollection<Pessoa> pessoas { get; set; }
    public Pagina01()
    {
      InitializeComponent();
      pessoas = new ObservableCollection<Pessoa>()
      {
        new Pessoa(){Nome="Pessoa 01"},
        new Pessoa(){Nome="Pessoa 02"}
      };
      lista01.ItemsSource = pessoas;
      MessagingCenter.Subscribe<Pagina02, Pessoa>(this, "CadastroPessoa", (sender, pessoa) => {
        pessoas.Add(pessoa);
      });
    }

    private void cadastrar(object sender, EventArgs e)
    {
      Navigation.PushAsync(new Pagina02());
    }
  }
}