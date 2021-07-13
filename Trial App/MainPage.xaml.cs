using System;
using Xamarin.Forms;

namespace Trial_App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void customrenderers(object sender, EventArgs e)
        {
            
            App.Current.MainPage = new NavigationPage(new Pages.Custom_Renderer_Trial.Page1());
            
        }

        private void localDB(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Pages.Local_Database.Page1());
        }

        private void snapchatLogin(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Pages.Snapchat_Login.Login());
        }

        private void todoApp(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Pages.ToDo_App.ToggleListTrial());
        }
    }
}
