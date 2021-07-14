using Android.Content;
using Android.Graphics.Drawables;
using Android.Widget;
using Trial_App.Custom_Renderers;
using Trial_App.Droid.Custom_Renderers_Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyEditor2), typeof(MyCustomEditorRenderer2))]

namespace Trial_App.Droid.Custom_Renderers_Android
{
    class MyCustomEditorRenderer2 : EditorRenderer
    {
        public MyCustomEditorRenderer2(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = Forms.Context.GetDrawable(Resource.Drawable.MyCustomEditor);
                //Control.SetPadding(10, 10, 10, 10);
                //Control.SetPaddingRelative(10, 10, 10, 10);

                //for custom cursor
                //EditText nativeEditText = (global::Android.Widget.EditText)Control;
                //nativeEditText.SetTextCursorDrawable(Resource.Drawable.CustomCursor);
            }
        }
    }
}