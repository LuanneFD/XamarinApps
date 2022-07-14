using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Controles.NavegadorControle
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Navegador : ContentPage
  {
    public Navegador()
    {
      InitializeComponent();
      var wvHtmlSource = new HtmlWebViewSource();
      wvHtmlSource.Html = @"
                             <html>
                                <body>
                                  <h1>Sou uma página<h1/>
                                  <h2>Dentro do WebView<h2/>
                                  <p>Este é um teste do nosso webview renderizando HTML e 
                                   <span style='color: red; text-decoration: underline; font-weight: bold'>CSS<span/>
                                  <p/>
                                 <body/>
                            <html/>";
      wv2.Source = wvHtmlSource;
    }

    private void Voltar_Clicked(object sender, EventArgs e)
    {
      if (wv3.CanGoBack) { wv3.GoBack(); }
    }

    private void Proximo_Clicked(object sender, EventArgs e)
    {
      if (wv3.CanGoForward) { wv3.GoForward(); }
    }

    private void Atualizar_Clicked(object sender, EventArgs e)
    {
      wv3.Reload();
    }

    private void wv3_Navigated(object sender, WebNavigatedEventArgs e)
    {
      lblstatus.Text = "Página carregada!";
      lblurl.Text = e.Url;
    }

    private void wv3_Navigating(object sender, WebNavigatingEventArgs e)
    {
      lblstatus.Text = "Página carregando...";
    }
  }
}