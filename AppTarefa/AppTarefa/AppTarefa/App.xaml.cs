using AppTarefa.Telas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTarefa
{
  public partial class App : Application
  {
    public App()
    {
      InitializeComponent();

      MainPage = new NavigationPage(new Listar());
    }

    protected override void OnStart()
    {
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
  }
}
