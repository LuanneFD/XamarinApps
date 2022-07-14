using AppTarefa.Modelos;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTarefa.Telas
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Visualizar : ContentPage
  {
    public Visualizar()
    {
      InitializeComponent();
    }

   public Visualizar(Tarefa tarefa)
    {
      InitializeComponent();
      BindingContext = tarefa;

      if(string.IsNullOrEmpty(tarefa.Nota))
      {
        lblNota.IsVisible = false;
      }
    }
    private void Voltar(object sender, EventArgs e)
    {
      Navigation.PopAsync();
    }
  }
}