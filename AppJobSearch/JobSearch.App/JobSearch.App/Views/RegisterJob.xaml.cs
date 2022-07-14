using JobSearch.App.Models;
using JobSearch.App.Services;
using JobSearch.App.Utility.Load;
using JobSearch.Domain.Models;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobSearch.App.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class RegisterJob : ContentPage
  {
    private JobService _service;
    public RegisterJob()
    {
      InitializeComponent();
      _service = new JobService();
    }

    private void Voltar(object sender, EventArgs e)
    {
      Navigation.PopAsync();
    }

    private async void SaveJob(object sender, EventArgs e)
    {
      txtMessages.Text = string.Empty;
      User user = JsonConvert.DeserializeObject<User>(App.Current.Properties["User"].ToString());

      Job job = new Job
      {
        Company = txtempresa.Text ?? "",
        JobTitle = txtcargo.Text ?? "",
        CityState = txtcidade.Text ?? "",
        Salary = txtsalario.Text == null ? 0 : Convert.ToDouble(txtsalario.Text),
        ContractType = rbCLT.IsChecked ? "CLT" : "PJ",
        TecnologyTools = txttecnologias.Text ?? "",
        CompanyDescription = txtdescempresa.Text ?? "",
        JobDescription = txtdesctrabalho.Text ?? "",
        Benefits = txtbeneficios.Text ?? "",
        InteressedSendEmailTo = txtemail.Text ?? "",
        UserId = user.Id
      };

      ResponseService<Job> responseService = await _service.AddJob(job);
      await Navigation.PushPopupAsync(new Loading());
      await Task.Delay(3000);
      if (responseService.IsSuccess)
      {
        await Navigation.PopAllPopupAsync();
        await DisplayAlert("Sucesso!", "Job salvo com sucesso.", "OK");
        await Navigation.PopAsync();
      }
      else
      {
        if (responseService.StatusCode == 400)
        {
          StringBuilder sb = new StringBuilder();
          foreach (var itemKey in responseService.Errors)
          {
            foreach (var itemValue in itemKey.Value)
            {
              _ = sb.AppendLine(itemValue);
            }
          }

          txtMessages.Text = sb.ToString();
        }
        else
        {
          await DisplayAlert("Erro", "Ocorreu um erro inesperado. Tente novamente mais tarde!", "Ok");
        }
        await Navigation.PopAllPopupAsync();
      }
    }

  }
}