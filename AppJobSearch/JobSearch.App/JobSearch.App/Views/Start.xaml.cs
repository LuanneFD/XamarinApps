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
  public partial class Start : ContentPage
  {
    public Start()
    {
      InitializeComponent();
    }

    private void GoJob(object sender, EventArgs e)
    {
      var eventArgs = (TappedEventArgs)e;
      var page = new Visualizer();
      page.BindingContext = eventArgs.Parameter;
      Navigation.PushAsync(page);
    }

    private void GoRegisterJob(object sender, EventArgs e)
    {
      Navigation.PushAsync(new RegisterJob());
    }

    private void FocusPesquisa(object sender, EventArgs e)
    {
      txtPesquisa.Focus();
    }

    private void FocusCidade(object sender, EventArgs e)
    {
      txtCidade.Focus();
    }

    private void Logout(object sender, EventArgs e)
    {
      App.Current.Properties.Remove("User");
      App.Current.SavePropertiesAsync();
      App.Current.MainPage = new Login();
    }
  }
}