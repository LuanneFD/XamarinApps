using Android.Content;
using JobSearch.App.Droid.Utility.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Editor), typeof(CustomEditorRender))]
namespace JobSearch.App.Droid.Utility.Controls
{
  public class CustomEditorRender : EditorRenderer
  {
    public CustomEditorRender(Context context) : base(context)
    {

    }

    protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
    {
      base.OnElementChanged(e);
      if (Control != null)
      {
        Control.Background = null; //retira o underline do campo editor no android.
        Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
      }
    }
  }
}