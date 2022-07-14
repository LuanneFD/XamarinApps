using JobSearch.App.Models;
using JobSearch.App.Services;
using JobSearch.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JobSearch.App.Utility.Load;

namespace JobSearch.App.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Login : ContentPage
  {
    //private UserService _service;
    public Login()
    {
      InitializeComponent();
      //_service = new UserService();
    }

    private void GoRegister(object sender, EventArgs e)
    {
      _ = Navigation.PushAsync(new Register());
    }

    private async void GoStart(object sender, EventArgs e)
    {
      //CODIDO COMENTADO PORQUE NÃO FOI POSSÍVEL PUBLICAR A API NO AZURE, MAS O CÓDIGO ESTÁ CORRETO.

      //string email = txtEmail.Text;
      //string password = txtPassword.Text;

      //ResponseService<User> responseService = await _service.GetUser(email, password);
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
      //if (responseService.StatusCode == 404)
      //{
        //  await DisplayAlert("Erro", "Usuário não encontrado.", "Ok");
      //}
      //else
      //{
        //  await DisplayAlert("Erro", "Ocorreu um erro inesperado. Tente novamente mais tarde!", "Ok");
      //}
      //}
      await Navigation.PopAllPopupAsync();
    }
  }
}