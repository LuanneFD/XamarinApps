using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Listas.CarouselView
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Carousel : ContentPage
  {
    private ObservableCollection<Colaborador> colaboradores { get; set; }
    public Carousel()
    {
      InitializeComponent();
      colaboradores = GetColaboradores();
      Carousel01.ItemsSource = colaboradores;
    }

    public class Colaborador
    {
      public string Nome { get; set; }
      public string Cargo { get; set; }
      public string Descricao { get; set; }
    }
    private ObservableCollection<Colaborador> GetColaboradores()
    {
      return new ObservableCollection<Colaborador>
      {
        new Colaborador(){Nome="Angélica Ribeiro",Cargo="Web Designer",Descricao="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s." },
        new Colaborador(){Nome="André Rodrigues",Cargo="Programador",Descricao="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s." },
        new Colaborador(){Nome="Aline Diaz",Cargo="Analista de Sistemas",Descricao="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s." },
        new Colaborador(){Nome="Matias Ribeiro",Cargo="Web Designer",Descricao="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s." }
      };
    }

    private void Carousel01_RemainingItemsThresholdReached(object sender, EventArgs e)
    {
      colaboradores.Add(new Colaborador() { Nome = "TESTE 01", Cargo = "Web Designer", Descricao = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s." });
      colaboradores.Add(new Colaborador() { Nome = "TESTE 02", Cargo = "Programador", Descricao = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s." });
      colaboradores.Add(new Colaborador() { Nome = "TESTE 03", Cargo = "Analista de Sistemas", Descricao = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s." });
      colaboradores.Add(new Colaborador() { Nome = "TESTE 04", Cargo = "Web Designer", Descricao = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s." });

      Carousel01.RemainingItemsThreshold = -1;
    }

    private void Carousel01_PositionChanged(object sender, PositionChangedEventArgs e)
    {
      lblPosition.Text = "Posição: " + e.CurrentPosition + " - Posição Anterior: " +e.PreviousPosition;
    }

    private void Carousel01_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
    {
      var colaborador = (Colaborador)e.CurrentItem;
      lblItem.Text = "Nome: " + colaborador.Nome;
    }
  }
}