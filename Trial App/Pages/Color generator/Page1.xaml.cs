using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trial_App.Pages.Color_generator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }
        Random r = new Random();
        private void generate(object sender, EventArgs e)
        {
            box.BackgroundColor = Color.FromRgba(r.Next(100, 256),r.Next(100, 256), r.Next(100, 256),200);
        }
    }
}