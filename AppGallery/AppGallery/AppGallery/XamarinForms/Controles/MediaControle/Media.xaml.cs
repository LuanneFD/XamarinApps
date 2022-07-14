using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Controles.MediaControle
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Media : ContentPage
  {
    private bool continuaAtualizando = true;
    public Media()
    {
      InitializeComponent();
    }

    private void Play(object sender, EventArgs e)
    {
      mediaElement.Play();
      continuaAtualizando = true;
      AtualizaVideoPosicao();
    }

    private void AtualizaVideoPosicao()
    {
      Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
      {
        lblposicao.Text = mediaElement.Position.ToString(@"mm\:ss");
        sldposicaovideo.Value = mediaElement.Position.Seconds;
        return continuaAtualizando;
      });
    }
    private void Pause(object sender, EventArgs e)
    {
      mediaElement.Pause();
      continuaAtualizando = false;
      AtualizaVideoPosicao();
    }

    private void Stop(object sender, EventArgs e)
    {
      mediaElement.Stop();
      continuaAtualizando = false;
      AtualizaVideoPosicao();
    }

    private void SliderVolume(object sender, ValueChangedEventArgs e)
    {
      mediaElement.Volume =  e.NewValue;
      lblvolume.Text = $"Volume({e.NewValue})";
    }

    private void mediaElement_MediaOpened(object sender, EventArgs e)
    {
      lblduracao.Text = mediaElement.Duration.Value.ToString(@"mm\:ss");
      sldposicaovideo.Maximum = mediaElement.Duration.Value.TotalSeconds;
    }
  }
}