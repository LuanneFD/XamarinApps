using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Concha.MenuHamburguer.Paginas
{
  [QueryProperty("Valor", "id")]
  [QueryProperty("Descricao", "tipo")]
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Coala : ContentPage
  {
    private string _valor { get; set; }
    private string _descricao { get; set; }
    public string Valor { 
      set
      {
        _valor = value;
      }
    }
    public string Descricao { set { _descricao = value; } }
    public Coala()
    {
      InitializeComponent();
    }

    protected override void OnAppearing()
    {
      lblparametropassado.Text = _descricao + " " + _valor;
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {    
      await Shell.Current.GoToAsync($"../raposa");
    }
  }
}