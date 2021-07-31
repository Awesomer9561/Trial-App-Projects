using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trial_App.Pages.Rest_Api
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            GetRegistration();
        }
        public async void GetRegistration()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://localhost:44338/api/TodoItems");
            var employee = JsonConvert.DeserializeObject<List<Model>>(response);
            LV.ItemsSource = employee;
        }


    }
}