using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Controles.ArrastaControle
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Arrasta : ContentPage
  {
    public Arrasta()
    {
      InitializeComponent();
    }

    private void SwipeItem_Invoked(object sender, EventArgs e)
    {
      lblDetalhe.Text = $"Acionado Detalhe: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} ";
    }

    private void SwipeItem_Invoked_1(object sender, EventArgs e)
    {
      lblEditar.Text = $"Acionado Editar: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} ";
    }

    private void SwipeItem_Invoked_2(object sender, EventArgs e)
    {
      lblExcluir.Text = $"Acionado Excluir: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} ";
    }

    private void SwipeView_SwipeStarted(object sender, SwipeStartedEventArgs e)
    {
      lblStarted.Text = $"Arrasto iniciado: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} ";
    }

    private void SwipeView_SwipeChanging(object sender, SwipeChangingEventArgs e)
    {
      lblChanging.Text = $"Arrasto em andamento: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} ";
    }

    private void SwipeView_SwipeEnded(object sender, SwipeEndedEventArgs e)
    {
      lblEnded.Text = $"Arrasto finalizado: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} ";
    }
  }
}