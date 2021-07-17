using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trial_App.Pages.Mini_tabbed_page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void OnFabTabTapped(object sender, Xamarin.CommunityToolkit.UI.Views.TabTappedEventArgs e)
        {

        }
    }
}