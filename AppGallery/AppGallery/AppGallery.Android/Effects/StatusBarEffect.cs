using Android.Views;
using AppGallery.Droid.Effects;
using Plugin.CurrentActivity;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(StatusBarEffect), "StatusBarEffect")]
namespace AppGallery.Droid.Effects
{
  public class StatusBarEffect : PlatformEffect
  {
    protected override void OnAttached()
    {
      var statusBarEffect = (Resources.Effects.StatusBarEffect)Element.Effects.FirstOrDefault(e => e is Resources.Effects.StatusBarEffect);

      if (statusBarEffect != null)
      {
        var backgroundColor = statusBarEffect.BackgroundColor.ToAndroid();
        Window currentWindow = GetCurrentWindow();
        currentWindow.SetStatusBarColor(backgroundColor);
      }
    }

    protected override void OnDetached()
    {

    }

    Window GetCurrentWindow()
    {
      var window = CrossCurrentActivity.Current.Activity.Window;

      window.ClearFlags(WindowManagerFlags.TranslucentStatus);
      window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

      return window;
    }
  }
}