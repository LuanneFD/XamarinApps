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
  public partial class CardHorizontal : ContentView
  {
    private string _titulo;
    private string _texto;
    private Color _cor;

    public string Titulo { get => _titulo; set { _titulo = value; CardTitulo.Text = _titulo; } }
    public string Texto { get => _texto; set { _texto = value; CardTexto.Text = _texto; } }
    public Color Cor { get => _cor; set { _cor = value; Card.BackgroundColor = _cor; } }

    public CardHorizontal()
    {
      InitializeComponent();
    }
  }
}