using AppTarefa.BancoDados;
using AppTarefa.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTarefa.Telas
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Listar : ContentPage
  {
    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private ObservableCollection<Tarefa> _lista;
    public ObservableCollection<Tarefa> Lista
    {
      get
      {
        return _lista;
      }
      set
      {
        _lista = value;
        NotifyPropertyChanged("Lista");
      }
    }
    public Listar()
    {
      InitializeComponent();
      AtualizarDataCalendario(DateTime.Now);
     
      MessagingCenter.Subscribe<Listar, Tarefa>(this, "TarefaCadastrada", (sender, tarefa) =>
      {
        if (Lista != null && DPCalendario.Date == tarefa.Data)
          Lista.Add(tarefa);
      });
    }

    private void btnCadastrar(object sender, EventArgs e)
    {
      Navigation.PushModalAsync(new Cadastrar());
    }

    private void VisualizarTarefa(object sender, EventArgs e)
    {
      var evento = (TappedEventArgs)e;
      var tarefa = (Tarefa)evento.Parameter;

      Navigation.PushAsync(new Visualizar(tarefa));
    }

    private async void Excluir(object sender, EventArgs e)
    {
      bool confirma = await DisplayAlert("Excluir", "Tem certeza que deseja excluir este registro?", "Sim", "Não");
      if (confirma)
      {
        var swipeItem = (SwipeItem)sender;
        var tarefa = (Tarefa)swipeItem.CommandParameter;

        bool excluido = await new TarefaDB().ExcluirAsync(tarefa.Id);

        if (excluido)
        {
          Lista.Remove(tarefa);
        }
      }
    }

    private async void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
      //Para identificar qual a tarefa, utilizamos o recurso do label do item, já que o CheckBox não tem propriedade 
      //de CommandParameter
      var check = (CheckBox)sender;
      var label = check.Parent.FindByName<Label>("lblTarefaDetalhe");
      if (label != null)
      {
        var tapGesture = (TapGestureRecognizer)label.GestureRecognizers[0];
        if (tapGesture != null)
        {
          var tarefa = (Tarefa)tapGesture.CommandParameter;
          if (tarefa != null)
          {
            await new TarefaDB().AlterarAsync(tarefa);
            AtualizaTextoTachado(label, tarefa.Finalizada);
          }
        }
      }
    }
 
    private void AbrirCalendario(object sender, EventArgs e)
    {
      DPCalendario.Focus(); //abre calendário
    }

    private void DPCalendario_DateSelected(object sender, DateChangedEventArgs e)
    {
      AtualizarDataCalendario(e.NewDate);
    }

    private void AtualizarDataCalendario(DateTime data)
    {
      Task.Run(() =>
      {
        //impede que o app fique travado enquando busca os dados e carrega na tela.
        //Para isso usa-se a thread principal.
        Device.BeginInvokeOnMainThread(async () =>
        {
          Lista = new ObservableCollection<Tarefa>(await new TarefaDB().PesquisarPorDataAsync(data));
          ListaTarefas.ItemsSource = Lista;
          QuantidadeTarefas.Text = Lista.Count.ToString();
        });
      });

      var idioma = CultureInfo.CurrentCulture;
      DiaDataAtual.Text = data.Date.Day.ToString();
      MesDataAtual.Text = PrimeiraLetraMaiuscula(data.ToString("MMMM",idioma)).Substring(0,3);
      DiaSemanaDataAtual.Text = PrimeiraLetraMaiuscula(idioma.DateTimeFormat.GetDayName(data.DayOfWeek));
    }

    private string PrimeiraLetraMaiuscula(string palavra)
    {
      return char.ToUpper(palavra[0]) + palavra.Substring(1);
    }

    private void AtualizaTextoTachado(Label label, bool finalizado)
    {
      if (finalizado)
      {
        label.TextDecorations = TextDecorations.Strikethrough;
      }
      else
      {
        label.TextDecorations = TextDecorations.None;
      }
    }
  }
}