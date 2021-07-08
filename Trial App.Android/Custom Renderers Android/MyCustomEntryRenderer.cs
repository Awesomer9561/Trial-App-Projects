using Android.Content;
using Trial_App.Droid.Custom_Renderers_Android;
using Trial_App.Custom_Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyCustomEntryRenderer))]

namespace Trial_App.Droid.Custom_Renderers_Android
{
    public class MyCustomEntryRenderer:EntryRenderer
    {
        public MyCustomEntryRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
            }
        }
    }
}