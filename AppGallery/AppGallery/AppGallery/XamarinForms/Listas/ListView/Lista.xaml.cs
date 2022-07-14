using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Listas.ListView
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Lista : ContentPage
  {
    public class Carro
    {
      public string Nome { get; set; }
      public string Motor { get; set; }
      public string Descricao { get; set; }
      public string ItemsDeSerie { get; set; }
    }
    public class Marca : List<Carro>
    {
      public string Nome { get; set; }
    }
    public Lista()
    {
      InitializeComponent();
      Lista01.ItemsSource = GetMarcas();
    }

    private List<Marca> GetMarcas()
    {
      return new List<Marca>()
      {
        GetListaCarrosFiat(),
        GetListaCarrosFord()
      };
    }

    private Marca GetListaCarrosFiat()
    {
     var fiat = new Marca()
      {
        new Carro{
          Nome="Mobi",
          Motor = "1.0",
          Descricao=@"Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.",
        ItemsDeSerie="Airgs-bags, direção hidráulica"},
        new Carro{
          Nome="Uno",
          Motor = "1.0 - 1.4",
          Descricao=@"Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
          ItemsDeSerie="Airgs-bags, direção hidráulica"},
        new Carro{
          Nome="Argo",
          Motor = "1.0 - 1.4",
          Descricao=@"Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
          ItemsDeSerie="Airgs-bags, direção hidráulica"},
         new Carro{
          Nome="Cronos",
          Motor = "1.0 - 1.4",
          Descricao=@"Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
          ItemsDeSerie="Airgs-bags, direção hidráulica"},
         new Carro{
          Nome="Toro",
          Motor = "1.8, 2.4, 2.0TD",
          Descricao=@"Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
          ItemsDeSerie="Airgs-bags, direção elétrica,Ar-condicionado"},
         new Carro{
          Nome="Gran Siena",
          Motor = "1.8",
          Descricao=@"Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
          ItemsDeSerie="Airgs-bags, direção elétrica,Ar-condicionado"},
         new Carro{
          Nome="Strada",
          Motor = "1.8",
          Descricao=@"Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
          ItemsDeSerie="Airgs-bags, direção elétrica,Ar-condicionado"},
         new Carro{
          Nome="Dublò",
          Motor = "1.8",
          Descricao=@"Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
          ItemsDeSerie="Airgs-bags, direção elétrica,Ar-condicionado"},
      };
      fiat.Nome = "FIAT";
      return fiat;
    }

    private Marca GetListaCarrosFord()
    {
      var ford = new Marca()
      {
        new Carro{
          Nome="Ka",
          Motor = "1.0",
          Descricao=@"Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.",
        ItemsDeSerie="Airgs-bags, direção hidráulica"},
        new Carro{
          Nome="Ka Sedan",
          Motor = "1.0 - 1.4",
          Descricao=@"Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
          ItemsDeSerie="Airgs-bags, direção hidráulica"},
        new Carro{
          Nome="Fusion",
          Motor = "1.0 - 1.4",
          Descricao=@"Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
          ItemsDeSerie="Airgs-bags, direção hidráulica"},
         new Carro{
          Nome="Ecosport",
          Motor = "1.0 - 1.4",
          Descricao=@"Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
          ItemsDeSerie="Airgs-bags, direção hidráulica"},
         new Carro{
          Nome="Novo Edge",
          Motor = "1.8, 2.4, 2.0TD",
          Descricao=@"Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
          ItemsDeSerie="Airgs-bags, direção elétrica,Ar-condicionado"},
         new Carro{
          Nome="Ranger",
          Motor = "1.8",
          Descricao=@"Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
          ItemsDeSerie="Airgs-bags, direção elétrica,Ar-condicionado"}
      };
      ford.Nome = "FORD";
      return ford;
    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {
      var parametro = ((MenuItem)sender).CommandParameter;
      var carro = (Carro)parametro;
      DisplayAlert("Clicou no visualizar", $"Registro: {carro.Nome}", "Ok");
    }

    private void Lista01_Refreshing(object sender, EventArgs e)
    {
      refresh.Text = "Refresh ativado!!";
      Lista01.IsRefreshing = false;
    }

    private void Lista01_Scrolled(object sender, ScrolledEventArgs e)
    {
      scrolled.Text = $"SCROLL: X:{e.ScrollX} - Y:{e.ScrollY}";
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
      var marcas = (List<Marca>)Lista01.ItemsSource;
      var ford = marcas[1];
      var ka = ford[0];
      Lista01.ScrollTo(ka,ScrollToPosition.Center,true);
    }

    private void Lista01_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
      DisplayAlert("Selecinado", "item selecionado", "OK");
    }

    private void Lista01_ItemTapped(object sender, ItemTappedEventArgs e)
    {
      DisplayAlert("Tocado", "item tocado", "OK");
    }
  }
}