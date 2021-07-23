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

        private void color(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Pages.Color_generator.Page1());
        }

        private void mintabbedpage(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Pages.Mini_tabbed_page.Page1());
        }

        private void texts(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Pages.Working_with_texts.Page1());
        }

        private void firebase(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Pages.Cloud_Storage.Page1());
        }

        private void mvvm(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Pages.MVVM.Page1());
        }
    }
}
