﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobSearch.App
{
  public partial class App : Application
  {
    public App()
    {
      InitializeComponent();

      //if (App.Current.Properties.ContainsKey("User"))
      //{
      //  MainPage = new NavigationPage(new Views.Start());
      //}
      //else
      //{
        MainPage = new NavigationPage(new Views.Login());
      //}
    }

    protected override void OnStart()
    {
      // Method intentionally left empty.
    }

    protected override void OnSleep()
    {
      // Method intentionally left empty.
    }

    protected override void OnResume()
    {
      // Method intentionally left empty.
    }
  }
}