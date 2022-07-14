using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Gestos
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Gestos : ContentPage
  {
    public Gestos()
    {
      InitializeComponent();
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
      tap.Text = $"Label tocada: {DateTime.Now.ToShortTimeString()}";
    }

    private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
    {
      pan.Text = $"Label tocada e arrastada: {DateTime.Now.ToShortTimeString()}";
    }

    private void PinchGestureRecognizer_PinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
    {
      pinch.Text = $"Zoom aplicado: {DateTime.Now.ToShortTimeString()}";
    }

    private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
    {
      swipe.Text = $"Label deslizada: {DateTime.Now.ToShortTimeString()}";
    }
  }
}