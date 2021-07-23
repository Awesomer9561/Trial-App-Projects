using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trial_App.Pages.Working_with_texts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        string[] colors = new string[20];
        Random r = new Random();
        public Page1()
        {
            InitializeComponent();
            setColors();
        }

        private void setColors()
        {
            colors[0] = "#eccc68";
            colors[1] = "#ff7f50";
            colors[2] = "#ff6b81";
            colors[3] = "#7bed9f";
            colors[4] = "#70a1ff";
            colors[5] = "#5352ed";
            colors[6] = "#1e90ff";
            colors[7] = "#2ed573";
            colors[8] = "#2d98da";
            colors[9] = "#a55eea";
            colors[10] = "#3867d6";
            colors[11] = "#34e7e4";
            colors[12] = "#0fbcf9";
            colors[13] = "#ff3f34";
            colors[14] = "#F8EFBA";
            colors[15] = "#F97F51";
            colors[16] = "#55E6C1";
            colors[17] = "#D6A2E8";
            colors[18] = "#55E6C1";
            colors[19] = "#25CCF7";

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var bgColor = Color.FromHex(colors[r.Next(0, 19)]);
            colorLabel.BackgroundColor = bgColor;
            string hex = bgColor.ToHex().ToString();
            colorLabel.Text = hex;
            System.Drawing.Color c = System.Drawing.Color.FromArgb(100, r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
            int x = c.ToArgb();
            ColorBox.BackgroundColor = Color.FromHex(hex);

            await Application.Current.MainPage.DisplayToastAsync("Color Changed Successfully");
        }
    }
}