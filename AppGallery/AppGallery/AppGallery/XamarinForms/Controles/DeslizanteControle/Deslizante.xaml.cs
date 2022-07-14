using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Controles.DeslizanteControle
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Deslizante : ContentPage
  {
    public Deslizante()
    {
      InitializeComponent();
    }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
      lblInfo1.Text = e.NewValue.ToString();
    }

    private void Slider_DragStarted(object sender, EventArgs e)
    {
      lblInfo2.Text = "Iniciou o arrasto!";
    }

    private void Slider_DragCompleted(object sender, EventArgs e)
    {
      lblInfo3.Text = "Completo";
    }

    private void Slider_ValueChanged_Step(object sender, ValueChangedEventArgs e)
    {
      int passos = 1;
      ((Slider)sender).Value = Math.Round(e.NewValue / passos) * passos;
      lbldica.Text = ((Slider)sender).Value.ToString();
    }
  }
}