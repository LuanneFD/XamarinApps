using AppTarefa.BancoDados;
using AppTarefa.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTarefa.Telas
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Cadastrar : ContentPage
  {
    public string Prioridade;
    public Cadastrar()
    {
      InitializeComponent();
      dataselecionada.Text = DateTime.Now.ToString("dd/MM/yyyy");
      rbNormal.IsChecked = true;
    }

    private void FecharModal(object sender, EventArgs e)
    {
      Navigation.PopModalAsync();
    }

    private async void SalvarTarefa(object sender, EventArgs e)
    {
      Tarefa tarefa = new Tarefa
      {
        Nome = Nome.Text,
        Data = Data.Date,
        HoraInicial = HoraInicial.Time,
        HoraFinal = HoraFinal.Time,
        Nota = Nota.Text,
        Finalizada = false,
        Prioridade = Prioridade
      };

      if (await ValidacaoAsync(tarefa))
      {
        if (await new TarefaDB().InserirAsync(tarefa))
        {
          MessagingCenter.Send<Listar, Tarefa>(new Listar(), "TarefaCadastrada", tarefa);
          await Navigation.PopModalAsync();
        }
      }
    }

    private async Task<bool> ValidacaoAsync(Tarefa tarefa)
    {
      bool validacao = true;

      if (tarefa.HoraInicial > tarefa.HoraFinal)
      {
        await DisplayAlert("Atenção!", "O horário de início não pode ser maior que o horário final.", "Ok");
        validacao = false;
      }
      if (tarefa.Nome == null)
      {
        await DisplayAlert("Atenção!","O nome deve ser preenchido.","Ok");
        validacao = false;
      }  
      if(tarefa.Nome != null && tarefa.Nome.Length < 5)
      {
        await DisplayAlert("Atenção!", "O nome deve ter pelo menos 5 caracteres.", "Ok");
        validacao = false;
      }
      return validacao;
    }
    private void Data_Unfocused(object sender, FocusEventArgs e)
    {
      dataselecionada.Text = ((DatePicker)sender).Date.ToString("dd/MM/yyyy");
    }

    private void DataTapped(object sender, EventArgs e)
    {
      Data.Focus();
    }

    private void HoraTapped(object sender, EventArgs e)
    {
      HoraInicial.Focus();
    }

    private void HoraInicial_Unfocused(object sender, FocusEventArgs e)
    {
      spanHoraInicial.Text = ((TimePicker)sender).Time.ToString(@"hh\:mm");
      HoraFinal.Focus();
    }

    private void HoraFinal_Unfocused(object sender, FocusEventArgs e)
    {
      spanHoraFinal.Text = ((TimePicker)sender).Time.ToString(@"hh\:mm");
    }

    private void rbPrioridade_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
      Prioridade = ((RadioButton)sender).Content.ToString();
    }
  }
}