using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Listas.ClassesEspeciais
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public class Produto
  {
    public string Nome { get; set; }
    public Double Valor { get; set; }
    public string Setor { get; set; }
  }
  public partial class DataTemplateSelector : ContentPage
  {
    public DataTemplateSelector()
    {
      InitializeComponent();
      lista01.ItemsSource = GetProdutos();
    }
    private List<Produto> GetProdutos()
    {
      return new List<Produto> {

        new Produto {Nome = "Arroz",Valor= 15.60,Setor= "Mercearia" },
        new Produto {Nome = "Feijão",Valor= 15.60,Setor= "Mercearia" },
        new Produto {Nome = "Macarrão",Valor= 15.60,Setor= "Mercearia" },
        new Produto {Nome = "Óleo",Valor= 15.60,Setor= "Mercearia" },
        new Produto {Nome = "Sal",Valor= 15.60,Setor= "Mercearia" },
        new Produto {Nome = "Açúcar",Valor= 15.60,Setor= "Mercearia" },
        new Produto {Nome = "Café",Valor= 15.60,Setor= "Mercearia" },
        new Produto {Nome = "Molho de Tomate",Valor= 15.60,Setor= "Mercearia" },
        new Produto {Nome = "Azeite",Valor= 15.60,Setor= "Mercearia" },

        new Produto {Nome = "Frutas",Valor= 15.60,Setor= "Feira" },
        new Produto {Nome = "Legumes",Valor= 15.60,Setor= "Feira" },
        new Produto {Nome = "Verduras",Valor= 15.60,Setor= "Feira" },
        new Produto {Nome = "Ovos",Valor= 15.60,Setor= "Feira" },
        new Produto {Nome = "Ervas/Temperos",Valor= 15.60,Setor= "Feira" },

        new Produto {Nome = "Bifes",Valor= 15.60,Setor= "Açougue" },
        new Produto {Nome = "Carne moída",Valor= 15.60,Setor= "Açougue" },
        new Produto {Nome = "Peixes",Valor= 15.60,Setor= "Açougue" },
        new Produto {Nome = "Salsichas",Valor= 15.60,Setor= "Açougue" },
        new Produto {Nome = "Carne de frango",Valor= 15.60,Setor= "Açougue" },
        new Produto {Nome = "Carne de porco",Valor= 15.60,Setor= "Açougue" },
      };
    } 
  }
  public class SetorDataTemplateSelector : Xamarin.Forms.DataTemplateSelector
  {
    public DataTemplate MerceariaTemplate { get; set; }
    public DataTemplate FeiraTemplate { get; set; }
    public DataTemplate AcougueTemplate { get; set; }
    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
      Produto produto = (Produto)item;
      if (produto.Setor == "Mercearia")
      {
        return MerceariaTemplate;
      }
      else if (produto.Setor == "Feira")
      {
        return FeiraTemplate;
      }
      else if (produto.Setor == "Açougue")
      {
        return AcougueTemplate;
      }
      return null;
    }
  }
}