using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Listas.CollectionView
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Collection : ContentPage
  {
    private ObservableCollection<Categoria> categorias { get; set; }
    public class FastFood
    {
      public string Nome { get; set; }
      public int QuantidadeFranquias { get; set; }
    }
    public class Categoria : List<FastFood>
    {
      public string Nome { get; set; }
    }
    public Collection()
    {
      InitializeComponent();
      colecao01.ItemsSource = GetCategorias();
      colecao02.ItemsSource = new List<FastFood>();
    }

    private ObservableCollection<Categoria> GetCategorias()
    {
      categorias = new ObservableCollection<Categoria>();
      var sanduiches = new Categoria()
      {
        new FastFood{Nome="Subway",QuantidadeFranquias=50000},
        new FastFood{Nome="McDonald's",QuantidadeFranquias=40000},
        new FastFood{Nome="Burguer King",QuantidadeFranquias=9000}
      };
      sanduiches.Nome = "Sanduiches";


      var pizzarias = new Categoria()
      {
        new FastFood{Nome="Pizza Hut",QuantidadeFranquias=1000},
        new FastFood{Nome="Dommino's",QuantidadeFranquias=8000}
      };
      pizzarias.Nome = "Pizzas";

      var variedades = new Categoria()
      {
        new FastFood{Nome="Starbucks",QuantidadeFranquias=30000},
        new FastFood{Nome="KFC",QuantidadeFranquias=2000},
        new FastFood{Nome="Taco Bell",QuantidadeFranquias=7000}
      };
      variedades.Nome = "Variedades";

      categorias.Add(sanduiches);
      categorias.Add(pizzarias);
      categorias.Add(variedades);

      return categorias;
    }

    private void colecao01_RemainingItemsThresholdReached(object sender, EventArgs e)
    {
      var restaurantes = new Categoria()
      {
        new FastFood{Nome="Marmitex",QuantidadeFranquias=10},
        new FastFood{Nome="Mix",QuantidadeFranquias=2},
        new FastFood{Nome="Marieta",QuantidadeFranquias=5},
        new FastFood{Nome="Churrascaria Brasil",QuantidadeFranquias=15},
        new FastFood{Nome="Churrascaria São Paulo",QuantidadeFranquias=20},
        new FastFood{Nome="Churrascaria Gaucha",QuantidadeFranquias=9},
        new FastFood{Nome="Churrascaria Fogo de Chão",QuantidadeFranquias=20}
      };
      restaurantes.Nome = "Restaurantes";

      categorias.Add(restaurantes);
      colecao01.RemainingItemsThreshold = -1; //faz com que não busque mais elementos
    }

    private void colecao01_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (FastFood item in colecao01.SelectedItems)
      {
        stringBuilder.Append(item.Nome + " - ");
      }
      lblitens.Text = "*Itens selecionados: " + stringBuilder.ToString();
    }
  }
}