using Android.Content;
using JobSearch.App.Droid.Utility.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry),typeof(CustomEntryRender))]
namespace JobSearch.App.Droid.Utility.Controls
{
  public class CustomEntryRender : EntryRenderer
  {
    public CustomEntryRender(Context context) : base(context)
    {

    }

    protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
    {
      base.OnElementChanged(e);
      if (Control != null)
      {
        Control.Background = null; //retira o underline do campo entry no android.
        Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
      }
    }
  }
}