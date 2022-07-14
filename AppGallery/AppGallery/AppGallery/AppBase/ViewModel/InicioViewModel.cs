using System.Collections.Generic;
using System.ComponentModel;
using AppGallery.AppBase.Models;

namespace AppGallery.AppBase.ViewModel 
{
  public class InicioViewModel : INotifyPropertyChanged
  {
    public List<Pagina> PageListBackup { get; set; }
    private List<Pagina> _PageList;
    public List<Pagina> PageList
    {
      get { return _PageList; }
      set
      {
        _PageList = value;
        RaisePropertyChanged(nameof(PageList));
      }
    }
    public InicioViewModel()
    {
      PageListBackup = CarregaMenuItens(App.MenuItensColecao);
      PageList = CarregaMenuItens(App.MenuItensColecao);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void RaisePropertyChanged(string prop)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
    public void Pesquisa(string textoPesquisa)
    {
      var listaFiltrada = new List<Pagina>();
      foreach (var pagina in PageListBackup)
      {
        if (pagina.Nome.ToUpper().Contains(textoPesquisa.ToUpper().Trim()))
        {
          listaFiltrada.Add(pagina);
        }
      }
      PageList = listaFiltrada;
    }
    private List<Pagina> CarregaMenuItens(List<PaginaColecao> paginas)
    {
      var listaPagina = new List<Pagina>();
      foreach (var item in paginas)
      {
        listaPagina.AddRange(item);
      }
      return listaPagina;
    }
  }
}
