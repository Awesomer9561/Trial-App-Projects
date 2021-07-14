using Android.Content;
using Android.Graphics.Drawables;
using Trial_App.Droid.Custom_Renderers_Android;
using Trial_App.Custom_Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyEditor), typeof(MyCustomEditorRenderer))]


namespace Trial_App.Droid.Custom_Renderers_Android
{

    class MyCustomEditorRenderer : EditorRenderer
    {
        public MyCustomEditorRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control!=null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
}