using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trial_App.Pages.Rest_Api
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Additem : ContentPage
    {
        public Additem()
        {
            InitializeComponent();
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            Model item = new Model()
            {
                Name = ToDoItemEntry.Text,
                isDone = false
            };
            var httpClient = new HttpClient();
            var Json = JsonConvert.SerializeObject(item);
            HttpContent httpContent = new StringContent(Json);

            HttpContent content = new StringContent(Json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = httpClient.PostAsync("https://localhost:44338/api/TodoItems", content).Result;

            DisplayAlert("Status", response.StatusCode.ToString(), "OK");
            //DisplayAlert("Added", "Your Data has been added", "OK");
        }
    }
}