using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Listas.ClassesEspeciais
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class NotifyProperty : ContentPage
  {
    public ObservableCollection<Carro> lista { get; set; }
    public class Carro :INotifyPropertyChanged
    {
      private string _nome;
      private string _motor;
      public string Nome { get => _nome; set { _nome = value; RaisePropertyChanged("Nome"); } }
      public string Motor { get => _motor; set { _motor = value; RaisePropertyChanged("Motor"); } }

      public event PropertyChangedEventHandler PropertyChanged;

      private void RaisePropertyChanged(string prop)
      {
        if(PropertyChanged != null)
        {
          PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
      }
    }


    public NotifyProperty()
    {
      InitializeComponent();
      Lista01.ItemsSource = new List<Carro> {
      new Carro(){Nome="FIAT UNO",Motor="1.0"}
      };
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
      string nome = Nome.Text;
      string motor = Motor.Text;

      var lista = (List<Carro>)Lista01.ItemsSource;
      lista[0].Nome = nome;
      lista[0].Motor = motor;
    }
  }
}