using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppQuantidade
{
  public partial class MainPage : ContentPage
  {
    int quantidade = 1;
    public MainPage()
    {
      InitializeComponent();
    }

    private void Somar(object sender, EventArgs e)
    {
      quantidade++;
      lblQuantidade.Text = quantidade.ToString();
    }

    private void Subtrair(object sender, EventArgs e)
    {
      if (quantidade != 0)
      {
        quantidade--;
        lblQuantidade.Text = quantidade.ToString();
      }
    }
  }
}
