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
