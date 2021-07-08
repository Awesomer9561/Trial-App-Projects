using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trial_App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void login(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Snapchat_Login.Login());
        }

        private void signUp(object sender, EventArgs e)
        {

        }
    }
}