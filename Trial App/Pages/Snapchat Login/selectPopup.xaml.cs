using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trial_App.Pages.Snapchat_Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class selectPopup : Popup
    {
        public selectPopup()
        {
            InitializeComponent();
        }

        private void viaPhone(object sender, EventArgs e)
        {

        }

        private void viaEmail(object sender, EventArgs e)
        {

        }

        private void closePopup(object sender, EventArgs e)
        {
            Dismiss(null);

        }
    }
}