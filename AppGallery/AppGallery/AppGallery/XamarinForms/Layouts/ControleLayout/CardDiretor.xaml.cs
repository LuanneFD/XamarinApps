using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Layouts.ControleLayout
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class CardDiretor : ContentView
  {
    public static readonly BindableProperty NomeProperty = BindableProperty.Create("Nome", typeof(string), typeof(CardDiretor));
    public static readonly BindableProperty DescricaoProperty = BindableProperty.Create("Descricao", typeof(string), typeof(CardDiretor));
    public static readonly BindableProperty BoxViewColorProperty = BindableProperty.Create("BoxViewColor", typeof(Color), typeof(CardDiretor));

    public string Nome { get => (string)GetValue(NomeProperty); set => SetValue(NomeProperty, value); }
    public string Descricao { get => (string)GetValue(DescricaoProperty); set => SetValue(DescricaoProperty, value); }
    public Color BoxViewColor { get => (Color)GetValue(BoxViewColorProperty); set => SetValue(BoxViewColorProperty, value); }
    public CardDiretor()
    {
      InitializeComponent();
    }
  }
}