using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Controles.DataSelecaoControle
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class DataControle : ContentPage
  {
    public DataControle()
    {
      InitializeComponent();
    }

    private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
      lblinfo.Text = "Data antiga: " + e.OldDate.ToString("dd/MM/yyyy") + "| Data atual: " + e.NewDate.ToString("dd/MM/yyyy");
    }
  }
}