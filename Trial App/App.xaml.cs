using System;
using System.IO;
using Trial_App.Pages;
using Trial_App.Pages.Local_Database;
using Xamarin.Forms;

namespace Trial_App
{
    public partial class App : Application
    {
        private static SampleData database;
        public static SampleData Database
        {
            get
            {
                if (database == null)
                {
                    database = new SampleData(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "sampleList.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            //MainPage = new NavigationPage(new Pages.Mini_tabbed_page.Page1());
            //MainPage = new NavigationPage(new Pages.Color_generator.Page1());
            //MainPage = new NavigationPage(new Pages.ToDo_App.ToggleListTrial());
            //MainPage = new NavigationPage(new Pages.Custom_Renderer_Trial.Page1());
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
