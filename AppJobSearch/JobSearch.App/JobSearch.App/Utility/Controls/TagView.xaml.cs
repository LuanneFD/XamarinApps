﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobSearch.App.Utility.Controls
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class TagView : ContentView
  {
    public static readonly BindableProperty TecnologiesProperty = BindableProperty.Create("Tecnologies",typeof(string),typeof(TagView));
    public string Tecnologies
    {
      get => (string)GetValue(TagView.TecnologiesProperty);
      set => SetValue(TagView.TecnologiesProperty, value);
    }

    public static readonly BindableProperty NumberOfWordsProperty = BindableProperty.Create("NumberOfWords", typeof(int), typeof(TagView));
    public int NumberOfWords
    {
      get => (int)GetValue(TagView.NumberOfWordsProperty);
      set => SetValue(TagView.NumberOfWordsProperty, value);
    }
    public TagView()
    {
      InitializeComponent();
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      if(propertyName == "Tecnologies" && Tecnologies != null)
      {
        Container.Children.Clear();
        string [] words = Tecnologies.Split(',');
        if (NumberOfWords == 0) NumberOfWords = words.Count();
        int limite = (words.Count() >= NumberOfWords) ? NumberOfWords : words.Count();

        for (int i = 0; i < limite; i++)
        {
          Frame frame = new Frame() { BackgroundColor = Color.LightGray, Padding = new Thickness(3), HasShadow = false };
          Label label = new Label()
          {
            Text = words[i],
            Padding = new Thickness(3),
            FontFamily= "MontserratLight",
            FontSize = 10,
            TextColor = Color.FromHex("#8D9EAA")
          };
          frame.Content = label;
          Container.Children.Add(frame);
        }
      }
      base.OnPropertyChanged(propertyName);
    }
  }
}