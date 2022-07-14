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
  public partial class Register : ContentPage
  {
    private UserService _service;
    public Register()
    {
      InitializeComponent();
      _service = new UserService();
    }

    private void Voltar(object sender, EventArgs e)
    {
      Navigation.PopAsync();
    }

    private async void Save(object sender, EventArgs e)
    {
      //txtMessages.Text = string.Empty;
      //User user = new User
      //{
      //  Email = txtemail.Text,
      //  Name = txtnome.Text,
      //  Password = txtsenha.Text
      //};

      //ResponseService<User> responseService = await _service.AddUser(user);
      await Navigation.PushPopupAsync(new Loading());
      await Task.Delay(3000);
      //if (responseService.IsSuccess)
      //{
      //  App.Current.Properties.Add("User", JsonConvert.SerializeObject(responseService.Data));
      //  await App.Current.SavePropertiesAsync(); //sem este código, o usuário não é salvo nas propriedades e não permanece logado
        Application.Current.MainPage = new NavigationPage(new Start());

      //}
      //else
      //{
      //  if (responseService.StatusCode == 400)
      //  {
      //    StringBuilder sb = new StringBuilder();
      //    foreach (var itemKey in responseService.Errors)
      //    {
      //      foreach (var itemValue in itemKey.Value)
      //      {
      //        _ = sb.AppendLine(itemValue);
      //      }
      //    }

      //    txtMessages.Text = sb.ToString();
      //  }
      //  else
      //  {
      //    await DisplayAlert("Erro", "Ocorreu um erro inesperado. Tente novamente mais tarde!", "Ok");
      //  }
      //}
      await Navigation.PopAllPopupAsync();
    }
  }
}