using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Listas.ClassesEspeciais
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class ObservableCollection : ContentPage
  {
    public ObservableCollection<Pessoa> lista {get;set;}
    public class Pessoa
    {
      public string Nome { get; set; }
      public string Sobrenome { get; set; }
    }
    public ObservableCollection()
    {
      InitializeComponent();
      lista = getlistapessoas();
      Lista01.ItemsSource = lista;
    }

    private void AdicionarItem(object sender, EventArgs e)
    {
      lista.Add(new Pessoa() { Nome = "Maria", Sobrenome = "Rodrigues" });
    }

    private void RemoverItem(object sender, EventArgs e)
    {
      lista.RemoveAt(0);
    }

    private ObservableCollection<Pessoa> getlistapessoas()
    {
      return new ObservableCollection<Pessoa>() {
      new Pessoa { Nome = "Luanne", Sobrenome = "Ferreira" }
      };
    }
  }
}