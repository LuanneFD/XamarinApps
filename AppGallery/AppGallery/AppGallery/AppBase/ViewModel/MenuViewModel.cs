using AppGallery.AppBase.Models;
using System.Collections.Generic;

namespace AppGallery.AppBase.ViewModel
{
  public class MenuViewModel 
  {
    public List<PaginaColecao> MenuItens { get; set; }
    public MenuViewModel()
    {
      MenuItens = App.MenuItensColecao;
    }
  }
}
