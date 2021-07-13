using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms.Xaml;

namespace Trial_App.Pages.Snapchat_Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPopup : PopupPage
    {
        public MyPopup()
        {
            InitializeComponent();
        }

        private void closePopup(object sender, EventArgs e)
        {
            PopupNavigation.PopAsync();
        }

        private void viaEmail(object sender, EventArgs e)
        {

        }

        private void viaPhone(object sender, EventArgs e)
        {

        }
    }
}