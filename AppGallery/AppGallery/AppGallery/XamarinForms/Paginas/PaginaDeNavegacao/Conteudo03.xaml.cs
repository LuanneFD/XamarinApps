using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Paginas.PaginaDeNavegacao
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Conteudo03 : ContentPage
  {
    public Conteudo03()
    {
      InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
      return true;
      //NavigationPage.HasBackButton="False" colocado no XAML e código que impede de voltar a página pelo botão do celular.
    }

    private void VoltarParaPaginaAnterior(object sender, EventArgs e)
    {
      Navigation.PopAsync();
    }

    private void VoltarParaInicio(object sender, EventArgs e)
    {
      Navigation.PopToRootAsync(); //Volta para a página de início e limpa o histórico da pilha.
    }

    private void InserirPaginaPilha(object sender, EventArgs e)
    {
      Navigation.InsertPageBefore(new PaginaInserida(), Navigation.NavigationStack[0]);

      //2 - Exemplo da pilha: Navigation.NavigationStack[0];
      //1- qual a página será inserida, 2- antes de qual página será inserido.
      //neste exemplo a pagina 'PaginaInserida' será inserida no início da pilha.
    }

    private void RemoverPaginaPilha(object sender, EventArgs e)
    {
      Navigation.RemovePage(Navigation.NavigationStack[0]);
    }
  }
}