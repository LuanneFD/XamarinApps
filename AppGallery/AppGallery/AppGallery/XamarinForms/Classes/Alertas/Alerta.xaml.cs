using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Classes.Alertas
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Alerta : ContentPage
  {
    public Alerta()
    {
      InitializeComponent();
    }

    private void displayalert(object sender, EventArgs e)
    {
      DisplayAlert("Meu Display alert", "Clique no ok", "OK");
    }

    private async void displayactionsheet(object sender, EventArgs e)
    {
    string resultado = await DisplayActionSheet("Escolha sua marca favorita", "OK",null, "Boticário", "Aguá de Cheiro", "Nívea");
    }

    private async void displayprompt(object sender, EventArgs e)
    {
      string nome = await DisplayPromptAsync("Nome", "Insira o nome", "OK", "Cancelar", "nome..");
    }
  }
}