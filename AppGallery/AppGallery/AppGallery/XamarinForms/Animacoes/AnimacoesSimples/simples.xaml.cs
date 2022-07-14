using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.XamarinForms.Animacoes.AnimacoesSimples
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Simples : ContentPage
  {
    public Simples()
    {
      InitializeComponent();
    }

    private async void btnTranslate(object sender, EventArgs e)
    {
      await box.TranslateTo(100, 50, 500, Easing.BounceOut);
      await box.TranslateTo(0, 0, 1000, Easing.Linear);
    }

    private async void btnRotation(object sender, EventArgs e)
    {
      await box.RotateTo(90, 1000, Easing.CubicIn);
      await box.RotateTo(0, 1000, Easing.SpringOut);
    }

    private async void btnScale(object sender, EventArgs e)
    {
      await box.ScaleTo(2, 500, Easing.SinIn);
      await box.ScaleTo(1, 1000, Easing.SinOut);
    }

    private async void btnOpacity(object sender, EventArgs e)
    {
      await box.FadeTo(0.3, 500, Easing.Linear);
      await box.FadeTo(1, 1000, Easing.Linear);
    }

    private async void btnCombinada(object sender, EventArgs e)
    {
      await Task.WhenAll(
       box.TranslateTo(0, 150, 1000, Easing.BounceOut),
       box.ScaleTo(1.5, 1000, Easing.SinIn),
       box.RotateTo(45, 1000, Easing.SpringOut)
      );
      await Task.Delay(1000);
      await Task.WhenAll(
        box.TranslateTo(0, 0, 1000, Easing.BounceOut),
       box.ScaleTo(1, 1000, Easing.SinIn),
       box.RotateTo(0, 1000, Easing.SpringOut));
    }

    private async void btnPersonalizada(object sender, EventArgs e)
    {
      var animacao = new Animation(v => box.CornerRadius = v, 5, 30, Easing.Linear);
      animacao.Commit(box, "CornerAnimation", 300, 1000, Easing.SpringIn, null, () => false);

      await Task.Delay(3000);
      
      var animacao2 = new Animation(v => box.CornerRadius = v, 100, 0, Easing.Linear);
      animacao2.Commit(box, "CornerAnimation", 300, 1000, Easing.SpringIn, null, () => false);
    }

    private async void btntrocacor(object sender, EventArgs e)
    {
     await box.ColorTo(box.Color, Color.FromHex(txtcolor.Text), a => box.Color = a, 5000, Easing.Linear);
    }

    private void btncancelar(object sender, EventArgs e)
    {
      box.AbortAnimation("ColorTo");
      //ViewExtensions.CancelAnimation(box); Cancela todas as animações
    }
  }
  public static class ViewExtensions
  {
    public static Task<bool> ColorTo(this VisualElement self, Color fromColor, Color toColor, Action<Color> callback, uint length = 250, Easing easing = null)
    {
      Func<double, Color> transform = (t) =>
        Color.FromRgba(fromColor.R + t * (toColor.R - fromColor.R),
                       fromColor.G + t * (toColor.G - fromColor.G),
                       fromColor.B + t * (toColor.B - fromColor.B),
                       fromColor.A + t * (toColor.A - fromColor.A));
      return ColorAnimation(self, "ColorTo", transform, callback, length, easing);
    }

    public static void CancelAnimation(this VisualElement self)
    {
      self.AbortAnimation("ColorTo");
    }

    static Task<bool> ColorAnimation(VisualElement element, string name, Func<double, Color> transform, Action<Color> callback, uint length, Easing easing)
    {
      easing = easing ?? Easing.Linear;
      var taskCompletionSource = new TaskCompletionSource<bool>();

      element.Animate<Color>(name, transform, callback, 16, length, easing, (v, c) => taskCompletionSource.SetResult(c));
      return taskCompletionSource.Task;
    }
  }
}