using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trial_App.Pages.Snapchat_Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void forgotPass(object sender, EventArgs e)
        {
            //Navigation.ShowPopup(new selectPopup());
            //Navigation.PushAsync(new SecondPopup());
            //forgotPassPopup.IsVisible = true;

            PopupNavigation.PushAsync(new Pages.Snapchat_Login.MyPopup());
        }

        private void activateLoginBtn(object sender, EventArgs e)
        {
            loginBtn.IsEnabled = true;
        }

        private void closePopup(object sender, EventArgs e)
        {
            
        }

        private void logIn(object sender, EventArgs e)
        {

        }
    }
}